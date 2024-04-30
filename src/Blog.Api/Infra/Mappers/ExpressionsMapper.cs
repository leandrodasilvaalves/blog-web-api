using System.Linq.Expressions;

namespace Blog.Api.Infra.Mappers;

public class ExpressionsMapper<TSource, TDestination>
{
    public static Expression<Func<TDestination, bool>> Map(Expression<Func<TSource, bool>> predicate)
    {
        var parameter = Expression.Parameter(typeof(TDestination), "x");
        var visitor = new ParameterReplacer(predicate.Parameters.First(), parameter);

        var body = visitor.Visit(predicate.Body);
        return Expression.Lambda<Func<TDestination, bool>>(body, parameter);
    }

    private class ParameterReplacer(ParameterExpression sourceParameter, ParameterExpression targetParameter) : ExpressionVisitor
    {
        private readonly ParameterExpression _sourceParameter = sourceParameter;
        private readonly ParameterExpression _targetParameter = targetParameter;

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
            {
                var property = typeof(TDestination).GetProperty(node.Member.Name);
                if (property == null)
                {
                    throw new ArgumentException(
                            $"Property '{node.Member.Name}' is not defined for type '{typeof(TDestination).FullName}'", nameof(property));
                }

                return Expression.Property(_targetParameter, property);
            }

            return base.VisitMember(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _sourceParameter ? _targetParameter : base.VisitParameter(node);
        }
    }
}