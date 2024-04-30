using System.Linq.Expressions;

using Blog.Api.Domain.Contracts.Entities;
using Blog.Api.Domain.Data;
using Blog.Api.Infra.Data.Context.Mongo;
using Blog.Api.Infra.Data.Models;
using Blog.Api.Infra.Mappers;

using MongoDB.Driver;

namespace Blog.Api.Infra.Data;

public class DbData<TEntity, TModel> : IData<TEntity>
    where TEntity : Entity
    where TModel : DbModel
{
    private readonly IMongoDbContext<TModel> _context;
    private readonly IMapper<TEntity, TModel> _mapper;

    public DbData(IMongoDbContext<TModel> context, IMapper<TEntity, TModel> mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var model = _mapper.Map(entity);
        return _context.Collection.InsertOneAsync(model, new(), cancellationToken);
    }

    public async Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var model = await _context.Collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        return _mapper.Map(model);
    }

    public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var predicate2 = ExpressionsMapper<TEntity, TModel>.Map(predicate);
        var model = await _context.Collection.Find(predicate2).FirstOrDefaultAsync(cancellationToken);
        return _mapper.Map(model);
    }
}