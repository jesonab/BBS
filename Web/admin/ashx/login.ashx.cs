using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Web.admin.ashx
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string json = "{'info':'登录失败','ID':-1}";

            //获取GET方法传递参数：Request.QueryString["参数名称"];
            //获取POST方法传递参数：Request.Form["参数名称"];
            string txtuname = context.Request.Form["uname"]; //保存文本框对象，提高效率
            string txtupassword = context.Request.Form["PassWord"];

            BBS.BLL.BBSUsers bll = new BBS.BLL.BBSUsers();

            int n = bll.login(txtuname, txtupassword);
            //返回单个文字信息
            if (n > 0)
            {
                json = "{'info':'登录成功！','ID':" + n + "}";
                context.Session["ID"] = n;
                context.Session["Name"] = txtuname;
            }
            context.Response.Write(json);

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}