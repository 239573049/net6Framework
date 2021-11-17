using Swashbuckle.AspNetCore.SwaggerUI;

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
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "swagger";
                    c.DocExpansion(DocExpansion.List);
                });
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Run();
        }
    }
}
