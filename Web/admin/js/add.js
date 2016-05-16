$(document).ready(
function () {
    $("#yes").click(

         function() {

         
                 next();
           
         }
      );

    //点击注册按钮。获取登录名、密码、真实姓名。用弹出框显示出来。
    function next() {
        var uname = $("#uname").val(); //姓名
        var upassword = $("#upassword").val(); //密码
        var uemail = $("#uemail").val();  //邮箱
        var ubirthday = $("#ubirthday").val(); //生日
       
        var ustatement = $("#ustatement").val(); //签名

        //性别用布尔类型表示
        var adminSex = true;
        var sexCheck = $('input:radio[name="usex"]:checked').val();//得到单选按钮选中项的值
        if (sexCheck == '女') { adminSex = false; }

        //把数据传递到ashx文件里。然后把ashx回传的数据显示出来。
        $.ajax({
            type: "post",
            url: "ashx/add.ashx",
            data: { "Action": "add", "uname": uname, "upassword": upassword, "uemail": uemail, "usex": adminSex, "ubirthday": ubirthday, "ustatement": ustatement },
            dataType: "text",
            success: function (data) {
                var json = eval('(' + data + ')');
                alert(json.info);
                window.location.href = "../index.html";//页面跳转
            }, 
        });

      
    }
})