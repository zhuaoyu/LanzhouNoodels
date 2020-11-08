using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lanzhoubeefNoodefs.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;//1.5��using�������������
using Microsoft.EntityFrameworkCore.SqlServer;//1.5 ��Ϊʹ�����ݿ⣬����������������û�У����ʼ��������������NuGet,����sqlserver,Ȼ��װ���Ϳ���������
using Microsoft.Extensions.Configuration;//1.9���������ַ���ǰ������
using Microsoft.AspNetCore.Identity;//2.4�������


namespace lanzhoubeefNoodefs
{
    public class Startup
    {
        public IConfiguration Configuration { get; }//1.10��������������ݿ���ַ�����ֻ���͹���
        public Startup(IConfiguration configuration)//1.11ͨ�����캯��ʹ�����ݿ������ַ���
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//ע������齨���������Զ���ĺ�ϵͳ�Դ��ģ�
        {
            //1.6ע�����ݿ������ַ���.�����1.7��1.11���ٵ������ݿ������ַ���UseSqlServer(���洴���ĺ�����.get����������appsetting����ַ���������)
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //1.7�����Ŀ��������½������app��Ȼ�����Ӧ���ļ���appsettings.json��ת����ļ�
            services.AddMvc(options => { options.EnableEndpointRouting = false; })
             .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddControllers();//ע��MVC�������齨����
                                      // services.AddMvc();
            services.AddTransient<INoodleRepository, NoodleRepository>();//ע������  ����ģ��  MOCK�Ǽٲֿ� ���ڻ�����ֿ�
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();//����ģ��       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//����ϵͳhttp����ͨ��
        {//�м��middelware������������һ���м���Ĵ�������Ȼ������Լ��Ľ�����ݸ���һ���м��
            //һ��mvcΪ���һ���м������Щ��������·����ֱ����ǰ�������
            //�����м������һ��ͨ��������˳�����Ҫ
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();//������ʱ������wwwroot�ļ�
            app.UseAuthentication();//2.5�󶨿ؼ�������Identity���Ҽ���Ŀ���ƣ����ɡ�Ȼ���ڳ��������̨������2.6����
            app.UseRouting();
            //���·�ɹ����ͬ��app.UseMvcWithDefaultRoute();��ֻ�����ݿ����Զ����ˡ�
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
            });
            // app.UseMvcWithDefaultRoute();//���Ĭ�Ϲ��򣬴�home��index���������mvc�Ĵ��������޸ģ�


            // app.Map("/test", build =>//��һ������Ϊurl���ڶ�������Ϊ�������run��ʾ��·����
            //  {
            //     build.Run(async context => {
            //         await context.Response.WriteAsync("hello form test");//�ȴ����첽�����ַ���
            //      });
            // });

            app.UseEndpoints(endpoints =>
              {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
               });//������־1
              });//������־2

     

        }
    }
}

//���Ĳ�����ConfigureServices��ע�������������ַ����������ǽ��ܣ���services.AddTransient<�ӿ����ļ������ڶ������ģ�, ʵ�ֽӿ����ļ�������������,��Ҫusing����Model��>();
//AddTransient�����ŵ㣺ÿ�η������󴴽�һ��ȫ�µ������ֿ⣬�������Զ�ע�������ŵ㣺��ͬ���������ȫ����������Ӱ��
//AddSingleton:ϵͳ������ʱ�򴴽�һ�������ҽ���һ�����Ժ�ÿ�δ����������������������������һ���ֿ⣬������Ⱦ���ݿ⣩
//AddScoped�������ַ����ļ��ϣ����鷳һ��
//���岽����ʾ���ݣ�������ģ�͡��򿪿�����Home

//���ݿ�ע��������1.5��ʼ

//IdentityDbContext�����ã���2.4������ÿ�ʼ
//2.6 �ڳ��������̨���룺add-migration �Զ������ƣ�IdentityInit�� ���֮��
//2.7 ����update-database ����done�����ݿ�������  ��ʾasp.net�����֤������ʽ����