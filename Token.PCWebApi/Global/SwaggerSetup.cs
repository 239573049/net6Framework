﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Token.PCWebApi.Global
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerSetup
    {
        /// <summary>
        /// 
        /// </summary>
        public class Contact
        {
            /// <summary>
            /// 
            /// </summary>
            public string? Name
            {
                get;
                set;
            }
            /// <summary>
            /// 
            /// </summary>
            public string? Email
            {
                get;
                set;
            }
            /// <summary>
            /// 
            /// </summary>
            public Uri? Url
            {
                get;
                set;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="version"></param>
        /// <param name="title"></param>
        /// <param name="Description"></param>
        /// <param name="contact"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddSwaggerSetup(this IServiceCollection service, string version, string title, string Description, Contact contact)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }

            service.AddSwaggerGen(delegate (SwaggerGenOptions option)
            {
                option.SwaggerDoc(version, new OpenApiInfo
                {
                    Version = version,
                    Title = title,
                    Description = Description,
                    Contact = new OpenApiContact
                    {
                        Name = contact.Name,
                        Email = contact.Email,
                        Url = contact.Url
                    }
                });
                string[] files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");//获取api文档
                string[] array = files;
                foreach (string filePath in array)
                {
                    option.IncludeXmlComments(filePath, includeControllerXmlComments: true);
                }

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value,Format: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

            return service;
        }
    }
}
