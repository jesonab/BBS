$(document).ready(
function () {
	$("#fatie").click(

         function () {
         	next();

         }
      );

	//点击发帖按钮。获取帖子标题和帖子内容。
	function next() {
	   
		var ttopic = $("#ttopic").val(); //标题
		var tcontents = $("#tcontents").val(); //内容

		//把数据传递到ashx文件里。然后把ashx回传的数据显示出来。
		$.ajax({
			type: "post",
			url: "ashx/fatie.ashx",
			data: { "Action": "add", "ttopic": ttopic, "tcontents": tcontents },
			dataType: "text",
			success: function (data) {
				var json = eval('(' + data + ')');
				alert(json.info);
			},
		});


	}
})