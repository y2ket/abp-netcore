﻿namespace AbpLearning.Web.Core.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Abp.Configuration;
    using Abp.Extensions;
    using Abp.Runtime.Caching;
    using Abp.UI;
    using Application.Net.MimeTypes;
    using Application.Security.VerificationCodes;
    using Common.VerificationCode;
    using Microsoft.AspNetCore.Mvc;
    using Models.VerificationCode;

    [Route("api/[controller]/[action]")]
    public class VerificationCodeController : AbpLearningControllerBase
    {
        private readonly IVerificationCodeHelper _codeHelper;

        private readonly ICacheManager _cacheManager;

        private readonly ISettingManager _settingManager;

        public VerificationCodeController(IVerificationCodeHelper codeHelper, ICacheManager cacheManager, ISettingManager settingManager)
        {
            _codeHelper = codeHelper;
            _cacheManager = cacheManager;
            _settingManager = settingManager;
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="cacheKey">缓存key</param>
        /// <param name="tenantId">租户id（可选）</param>
        /// <returns>验证码图片</returns>
        [HttpGet]
        public async Task<FileContentResult> GenerateVerificationCode(string cacheKey, int? tenantId)
        {
            if (cacheKey.IsNullOrWhiteSpace())
            {
                return null;
            }

            // 是否启用
            if (false)
            {
                return null;
            }

            var imgStream = _codeHelper.Create(out var code);

            // 验证码key
            var key = "VerificationCode_Cache_Key";

            // 缓存，1分钟
            await _cacheManager.GetCache(key)
                .SetAsync(cacheKey, code.ToLower(), null, TimeSpan.FromMinutes(1));

            Response.Body.Dispose();

            return File(imgStream.ToArray(), MimeTypeNames.ImagePng);
        }

        /// <summary>
        /// 检查验证码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task ChcekVierificationCode([FromBody]VerificationCodeModel model)
        {
            // 检查验证码
            var result = await VerificationCodeService.CheckVerificationCode(_cacheManager,
                _settingManager,
                model.CacheKey,
                model.VerificationCode,
                model.TenantId);

            if (!result.IsNullOrEmpty())
            {
                throw new UserFriendlyException(L(result));
            }
        }
    }
}