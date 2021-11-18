using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Web.Configure
{
    public static class SwaggerSetup
    {
        public class Contact
        {
            public string? Name
            {
                get;
                set;
            }

            public string? Email
            {
                get;
                set;
            }

            public Uri? Url
            {
                get;
                set;
            }
        }

        public static void AddSwaggerSetup(this IServiceCollection service, string version, string title, string Description, Contact contact)
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
                string[] files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
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
        }
    }
}
