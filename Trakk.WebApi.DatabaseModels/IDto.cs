using System;

namespace Trakk.WebApi.DatabaseModels;


public interface IEntity
{
    public virtual TDto ToDto<TDto>() where TDto : IDto<TDto, IEntity>
    {
        return TDto.From(this);
    }
}

public interface IDto
{
}
public interface IDto<TModel> : IDto
{
    public TModel ToModel();
}

public interface IDto<out TDto,TModel> : IDto<TModel>
{
    public static abstract TDto From(TModel? model);
}


public static class EntityExtensions
{
    public static TDto ToDto<TEntity, TDto>(this TEntity? model) where TEntity : IEntity where TDto: IDto<TDto,TEntity>
    {
        return TDto.From(model);
    }
    
    public static TDto ToDto<TEntity, TDto>(this TEntity model, Func<TEntity, TDto> createFunc) where TEntity : IEntity
    {
        return createFunc(model);
    }
    
    public static TEntity ToEntity<TDto, TEntity>(this TDto dto) where TEntity : IEntity where TDto: IDto<TEntity>
    {
        return dto.ToModel();
    }
    
    public static TEntity ToEntity<TDto, TEntity>(this TDto dto, Func<TDto, TEntity> createFunc) where TEntity : IEntity
    {
        return createFunc(dto);
    }
}