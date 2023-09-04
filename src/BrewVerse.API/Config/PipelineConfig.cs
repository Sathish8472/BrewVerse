namespace BrewVerse.API.Config
{
    public static class PipelineConfig
    {
        public static void ConfigurePipeline(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); // Enable Swagger JSON endpoint
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrewVerse API V1"); // Configure Swagger UI
                    c.RoutePrefix = string.Empty; // Serve Swagger UI at the root URL
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
