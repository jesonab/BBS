using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Admin.ashx
{
    /// <summary>
    ///     Zhuce 的摘要说明
    /// </summary>
    public class add : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";

            string json = "{'info':'增加数据失败'}";
            //获取动作的类型
            string action = context.Request.Form["Action"];
            if (action == "add")
            {
                //获取GET方法传递参数：Request.QueryString["参数名称"];
                //获取POST方法传递参数：Request.Form["参数名称"];
                string txtuname = context.Request.Form["uname"]; //保存文本框对象，提高效率
                string txtupassword = context.Request.Form["upassword"];
                string txtuemail = context.Request.Form["uemail"];
                string adminSex = context.Request.Form["usex"];
                string txtubirthday = context.Request.Form["ubirthday"];
                string txtustatement = context.Request.Form["ustatement"];


                BBS.Model.BBSUsers model = new BBS.Model.BBSUsers();
                model.Uname = txtuname;//用户姓名
                model.UPassword = txtupassword;//用户密码
                model.UEmail = txtuemail;//用户邮箱
                model.UBirthday =DateTime.Parse(txtubirthday);//用户生日
                model.UStatement = txtustatement;//签名档
                model.URegDate = DateTime.Now;//用户注册时间
              
               model.Usex = false;//用户性别
                if (adminSex == "true") { model.Usex = true; }

                BBS.BLL.BBSUsers bll = new BBS.BLL.BBSUsers();
                int n = bll.Add(model);
                //返回单个文字信息
                if (n > 0) { json = "{'info':'增加数据成功,编号是：" + n + "'}"; }
            }
            else if (action == "Load")
            {
                if (context.Session["uid"] == null)
                {
                    json = "{'info':'no'}";
                }

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