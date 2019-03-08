﻿namespace AbpLearning.Application.Base
{
    using System.Threading.Tasks;
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 应用程序服务基接口（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput)
    /// </summary>
    public interface ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, in TGetPagedInput, TGetUpdateOutput, in TCreateInput, in TUpdateInput>
        : ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>>
       where TPrimaryKey : struct
        where TGetViewOutput : NullableIdDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TGetPagedOutput : IEntityDto<TPrimaryKey>
        where TGetUpdateOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : ICreateEntityDto
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
    }

    /// <summary>
    /// 应用程序服务基接口（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput,GetUpdateInput,GetViewInput)
    /// </summary>
    public interface ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, in TGetPagedInput, TGetUpdateOutput, in TCreateInput, in TUpdateInput,
        in TGetUpdateInput, in TGetViewInput>
        : ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, TGetPagedInput, TGetUpdateOutput, TCreateInput, TUpdateInput,
         TGetUpdateInput, TGetViewInput, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>>
       where TPrimaryKey : struct
        where TGetViewOutput : NullableIdDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TGetPagedOutput : IEntityDto<TPrimaryKey>
        where TGetUpdateOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : ICreateEntityDto
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetUpdateInput : IEntityDto<TPrimaryKey>
        where TGetViewInput : IEntityDto<TPrimaryKey>
    {
    }

    /// <summary>
    /// 应用程序服务基接口（基本方法：GetViewOutput,GetPaged,GetUpdateOutput,CreateInput,UpdateInput,GetUpdateInput,GetViewInput,UpdateOutput,CreateOutput,DeleteInput)
    /// </summary>
    public interface ICrudAsyncAppService<TPrimaryKey, TGetViewOutput,
        TGetPagedOutput, in TGetPagedInput, TGetUpdateOutput, in TCreateInput, in TUpdateInput,
        in TGetUpdateInput, in TGetViewInput, TUpdateOutput, TCreateOutput, in TDeleteInput>
        : IApplicationService
        where TPrimaryKey : struct
        where TGetViewOutput : NullableIdDto<TPrimaryKey>
        where TGetPagedInput : IPagedResultRequest
        where TGetPagedOutput : IEntityDto<TPrimaryKey>
        where TGetUpdateOutput : IEntityDto<TPrimaryKey>
        where TCreateInput : ICreateEntityDto
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetUpdateInput : IEntityDto<TPrimaryKey>
        where TGetViewInput : IEntityDto<TPrimaryKey>
        where TUpdateOutput : IEntityDto<TPrimaryKey>
        where TCreateOutput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        Task<TGetUpdateOutput> GetUpdateAsync(TGetUpdateInput input);

        Task<TGetViewOutput> GetViewAsync(TGetViewInput input);

        Task<PagedResultDto<TGetPagedOutput>> GetPagedAsync(TGetPagedInput input);

        Task<TCreateOutput> CreateAsync(TCreateInput input);

        Task<TUpdateOutput> UpdateAsync(TUpdateInput input);

        Task DeleteAsync(TDeleteInput input);
    }
}