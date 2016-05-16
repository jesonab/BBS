$(document).ready(function () {
	//注册提交按钮单击事件
	$("#BtnOK").click(function () {

		var uid = $("#uid").val(); //获取文本框的值
		var upassword = $("#upassword").val();
     
		if ("" != uid && "" != upassword ) {   //简单的验证放在客户端，减少服务器压力
			//利用post方式向服务器请求数据 
			$.ajax({
				type: "Post",
				url: "ashx/login.ashx",
				//方法传参的写法一定要对，UserName为形参的名字,PassWord为第二个形参的名字   
				data: { "uid": uid, "PassWord": upassword },
				dataType: "text",
				success: function (data) {
					//返回类型为text时 要处理一下 
					var json = eval('(' + data + ')');
					//   $("#result").val(json); 
					alert(json.info + " 编号为：" + json.ID);
				},
				error: function (err) {
					alert(err);
				}
			})
		}
		else {
			alert("输入非法！");
          
		}
	})
})