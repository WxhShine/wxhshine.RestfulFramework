using ASPCoreRestfulApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Model
{
    public class CompanyDto
    {
        public string Id { get; set; }
        public string CompanyName { get; set; }
    }

    [CompanyIntroductionValid]
    public class AddCompanyDto : IValidatableObject
    {
        [Display(Name = "公司名称")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]//{0} 占位显示为"公司名称"
        [MaxLength(100, ErrorMessage = "{0}这个字段必须小于{1}个字符")]//{1}占位符 代表 100 
        //ModelState.IsValid  //去验证以上Attribute
        public string Name { get; set; }
        public string Introduction { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == Introduction)
                yield return new ValidationResult("名称和简介一致", new[] { nameof(Name), nameof(Introduction) });
        }
    }

    public class CompanyIntroductionValidAttribute : ValidationAttribute
    {
        protected
            override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var addDto = (AddCompanyDto)validationContext.ObjectInstance;
            if (!addDto.Introduction.Contains(addDto.Name))
            {
                return new ValidationResult("简介中必须包含公司名称", new[] { nameof(addDto.Introduction) });
            }
            return ValidationResult.Success;
        }
    }

    public class RedisSetDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public TimeSpan? Expiry { get; set; }
    }
}
