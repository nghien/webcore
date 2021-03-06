﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WebCore.Utils.ModelHelper;

namespace WebCore.Utils.CollectionHelper
{
    public static class IQueryableExtension
    {
        public static ListResult<TModel> ToListResult<TModel>(this IQueryable<TModel> query)
        {
            List<TModel> listResult = query.ToList();
            return new ListResult<TModel>()
            {
                DataList = listResult
            };
        }

        private static void InitPagedModel<TModel>(this IQueryable<TModel> query, IPagingFilterDto pagingFilterDto, PagingResultDto<TModel> pagingModel)
        {
            pagingModel.RowCount = query.Count();
            pagingModel.PageSize = pagingFilterDto.PageSize;
            pagingModel.CurrentPage = pagingFilterDto.PageNumber;

            var pageCount = (double)pagingModel.RowCount / pagingModel.PageSize;
            pagingModel.PageCount = (int)Math.Ceiling(pageCount);

            IQueryable<TModel> queryResultPage = query
                  .Skip((pagingFilterDto.PageNumber - 1) * pagingFilterDto.PageSize)
                  .Take(pagingFilterDto.PageSize);

            pagingModel.Items = queryResultPage.ToList();
        }

        public static PagingResultDto<TModel> PagedQuery<TModel>(this IQueryable<TModel> query, IPagingFilterDto pagingFilterDto)
        {
            if (pagingFilterDto.PageNumber <= 0)
            {
                pagingFilterDto.PageNumber = 1;
            }
            var result = new PagingResultDto<TModel>();
            InitPagedModel(query, pagingFilterDto, result);
            return result;
        }

        public static SortingAndPagingResultDto<TModel> PagedAndSortingQuery<TModel>(this IQueryable<TModel> query, IPagingAndSortingFilterDto pagingFilterDto)
        {
            if (pagingFilterDto.PageNumber <= 0)
            {
                pagingFilterDto.PageNumber = 1;
            }
            var result = new SortingAndPagingResultDto<TModel>();
            InitPagedModel(query, pagingFilterDto, result);
            result.Sorting = pagingFilterDto.Sorting;
            return result;
        }

        private class LeftJoinIntermediate<TOuter, TInner>
        {
            public TOuter OneOuter { get; set; }
            public IEnumerable<TInner> ManyInners { get; set; }
        }

        private class Replacer : ExpressionVisitor
        {
            private readonly ParameterExpression _oldParam;
            private readonly Expression _replacement;

            public Replacer(ParameterExpression oldParam, Expression replacement)
            {
                _oldParam = oldParam;
                _replacement = replacement;
            }

            public override Expression Visit(Expression exp)
            {
                if (exp == _oldParam)
                {
                    return _replacement;
                }

                return base.Visit(exp);
            }
        }

        public static IQueryable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
        this IQueryable<TOuter> outer,
        IQueryable<TInner> inner,
        Expression<Func<TOuter, TKey>> outerKeySelector,
        Expression<Func<TInner, TKey>> innerKeySelector,
        Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            MethodInfo groupJoin = typeof(Queryable).GetMethods()
                                                     .Single(m => m.ToString() == "System.Linq.IQueryable`1[TResult] GroupJoin[TOuter,TInner,TKey,TResult](System.Linq.IQueryable`1[TOuter], System.Collections.Generic.IEnumerable`1[TInner], System.Linq.Expressions.Expression`1[System.Func`2[TOuter,TKey]], System.Linq.Expressions.Expression`1[System.Func`2[TInner,TKey]], System.Linq.Expressions.Expression`1[System.Func`3[TOuter,System.Collections.Generic.IEnumerable`1[TInner],TResult]])")
                                                     .MakeGenericMethod(typeof(TOuter), typeof(TInner), typeof(TKey), typeof(LeftJoinIntermediate<TOuter, TInner>));
            MethodInfo selectMany = typeof(Queryable).GetMethods()
                                                      .Single(m => m.ToString() == "System.Linq.IQueryable`1[TResult] SelectMany[TSource,TCollection,TResult](System.Linq.IQueryable`1[TSource], System.Linq.Expressions.Expression`1[System.Func`2[TSource,System.Collections.Generic.IEnumerable`1[TCollection]]], System.Linq.Expressions.Expression`1[System.Func`3[TSource,TCollection,TResult]])")
                                                      .MakeGenericMethod(typeof(LeftJoinIntermediate<TOuter, TInner>), typeof(TInner), typeof(TResult));

            Expression<Func<TOuter, IEnumerable<TInner>, LeftJoinIntermediate<TOuter, TInner>>> groupJoinResultSelector =
                                          (oneOuter, manyInners) => new LeftJoinIntermediate<TOuter, TInner> { OneOuter = oneOuter, ManyInners = manyInners };

            MethodCallExpression exprGroupJoin = Expression.Call(groupJoin, outer.Expression, inner.Expression, outerKeySelector, innerKeySelector, groupJoinResultSelector);

            Expression<Func<LeftJoinIntermediate<TOuter, TInner>, IEnumerable<TInner>>> selectManyCollectionSelector =
                                               t => t.ManyInners.DefaultIfEmpty();

            ParameterExpression paramUser = resultSelector.Parameters.First();

            ParameterExpression paramNew = Expression.Parameter(typeof(LeftJoinIntermediate<TOuter, TInner>), "t");
            MemberExpression propExpr = Expression.Property(paramNew, "OneOuter");

            LambdaExpression selectManyResultSelector = Expression.Lambda(new Replacer(paramUser, propExpr).Visit(resultSelector.Body), paramNew, resultSelector.Parameters.Skip(1).First());

            MethodCallExpression exprSelectMany = Expression.Call(selectMany, exprGroupJoin, selectManyCollectionSelector, selectManyResultSelector);

            return outer.Provider.CreateQuery<TResult>(exprSelectMany);
        }
    }
}
