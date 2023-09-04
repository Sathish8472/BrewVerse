namespace BrewVerse.API.Config
{
    public static class PipelineConfig
    {
        public static void ConfigurePipeline(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrewVerse API V1"); 
                    c.RoutePrefix = string.Empty; 
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
