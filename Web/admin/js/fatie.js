$(document).ready(
function () {
	$("#fatie").click(

         function () {
         	next();

         }
      );

	//���������ť����ȡ���ӱ�����������ݡ�
	function next() {
	   
		var ttopic = $("#ttopic").val(); //����
		var tcontents = $("#tcontents").val(); //����

		//�����ݴ��ݵ�ashx�ļ��Ȼ���ashx�ش���������ʾ������
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