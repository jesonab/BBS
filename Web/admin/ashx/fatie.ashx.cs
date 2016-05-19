using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS.BLL;

namespace web.admin.ashx
{
    /// <summary>
    /// fatie 的摘要说明
    /// </summary>
    public class fatie : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                //保存文本框对象，提高效率
                string ttopic = context.Request.Form["ttopic"];//帖子标题
                string tcontents = context.Request.Form["tcontents"];//帖子内容
                                                                     //string 


                BBS.Model.BBSTopic model = new BBS.Model.BBSTopic();
                model.TTopic = ttopic;//主题标题
                model.TContents = tcontents;//主贴内容
                model.tsid = 0;//板块编号
                model.TTime = DateTime.Now;//发帖时间？暂时不知道是否要删
                model.tuid = Convert.ToInt32(context.Session["ID"]);//发帖人编号
                model.treplycount = 0;//帖子回复次数
                model.TLastClickT = DateTime.Now;//最后点击时间？暂时不知道是否要删
                model.TClickCount = 0;//点击次数

                BBSTopic bll = new BBSTopic();
                int n = bll.Add(model);
                //返回单个文字信息
                if (n > 0) { json = "{'info':'增加数据成功,编号是：" + n + "'}"; }
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