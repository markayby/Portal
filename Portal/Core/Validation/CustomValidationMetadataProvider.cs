using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Portal.Core.Validation
{
    public class CustomValidationMetadataProvider : IValidationMetadataProvider
    {
        private ResourceManager resourceManager;
        private Type resourceType;

        public CustomValidationMetadataProvider(string baseName, Type type)
        {
            resourceType = type;
            resourceManager = new ResourceManager(baseName,
                type.GetTypeInfo().Assembly);
        }

        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                ValidationAttribute tAttr = attribute as ValidationAttribute;
                if (tAttr != null && tAttr.ErrorMessage == null
                                  && tAttr.ErrorMessageResourceName == null)
                {
                    var name = tAttr.GetType().Name;
                    if (resourceManager.GetString(name) != null)
                    {
                        tAttr.ErrorMessageResourceType = resourceType;
                        tAttr.ErrorMessageResourceName = name;
                        tAttr.ErrorMessage = null;
                    }
                }
            }
        }
    }
}