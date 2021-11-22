using Swashbuckle.AspNetCore.SwaggerUI;
using Web.Code.ChatHubs;
namespace Web.Configure
{
    public class AppConfigure
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <exception cref="Exception"></exception>
        public static void Configure(WebApplication? app)
        {
            if (app == null) throw new Exception("WebApplication is NUll");
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1/swagger.json", "Web Api");
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelsExpandDepth(-1);
            });
            app.UseCors("CorsPolicy");//CORS strategy
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("chatHub");
            });
            app.Run();//Run App
        }
    }
}
