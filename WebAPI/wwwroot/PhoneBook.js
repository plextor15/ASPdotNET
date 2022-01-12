function getRecord(id) {
	$.ajax({
		method: "GET",
		dataType: 'json',
		url: "https://localhost:44327/api/PhoneBook/"+id,
		cache: false
	})
		.done(function (response) {
			console.log(JSON.stringify(response));

			$("#id_field").val(response.id);
			$("#name_field").val(response.name);
			$("#country_prefix_field").val(response.countryPrefix);
			$("#number_field").val(response.number);
		})
		.fail(function (msg) {
			alert(JSON.stringify(msg));
		});
}

function getAllRecords() {
	$.ajax({
		method: "GET",
		dataType: 'json',
		url: "https://localhost:44327/api/PhoneBook/",
		cache: false
	})
		.done(function (response) {
			console.log(JSON.stringify(response));
			var ktory = 0;
			//powielanie
			$('#phoneData').append('');
		})
		.fail(function (msg) {
			alert(JSON.stringify(msg));
		});
}

function postRecord() {
	var new_element = {};
	//new_element.id = 15;
	//new_element.name = "Tom";
	//new_element.countryPrefix = "15";
	//new_element.number = "323 136 331";
	new_element.id = $("#id_field").val();
	new_element.name = $("#name_field").val();
	new_element.countryPrefix = $("#country_prefix_field").val();
	new_element.number = $("#number_field").val();
	console.log(JSON.stringify(new_element));
	$.ajax({
		method: "POST",
		dataType: 'json',
		contentType: "application/json; charset=utf-8",
		data: JSON.stringify(new_element),
		url: "https://localhost:44327/api/PhoneBook",
		cache: false
	})
		.done(function (response) {
			console.log(JSON.stringify(response));
		})
		.fail(function (msg) {
			alert(JSON.stringify(msg));
		});
}

function putRecord(id) {
	var new_element = {};
	//new_element.id = 3;
	//new_element.name = "Alex";
	//new_element.countryPrefix = "25";
	//new_element.number = "323 226 331";
	$.ajax({
		method: "PUT",
		dataType: 'json',
		contentType: "application/json; charset=utf-8",
		data: JSON.stringify(new_element),
		url: "https://localhost:44327/api/PhoneBook/"+id,
		cache: false
	})
		.done(function (response) {
			alert(JSON.stringify(response));
		})
		.fail(function (msg) {
			alert(JSON.stringify(msg));
		});
}

function deleteRecord(id) {
	$.ajax({
		method: "DELETE",
		dataType: 'json',
		url: "https://localhost:44327/api/PhoneBook/" + id,
		cache: false
	})
		.done(function (response) {
			console.log(JSON.stringify(response));
		})
		.fail(function (msg) {
			alert(JSON.stringify(msg));
		});
}



$(document).ready(function () {
	$("#id_field").prop("disabled", true);
	var id_field_is_active = false;

	$("#getAll").click(function () {
		getAllRecords();
	});

	$("#getOne").click(function () {
		//getRecord(2);
		getRecord($("#id_field").val());
	});

	$("#post").click(function () {
		postRecord();
	});

	$("#put").click(function () {
		putRecord(4);
	});

	$("#delete").click(function () {
		deleteRecord($("#id_field").val());
	})

	$("#activate_button").click(function () {
		console.log(id_field_is_active);
		if (id_field_is_active) {
			$(this).text("On");
			$("#id_field").prop("disabled", true);
		}
		else {
			$(this).text("Off");
			$("#id_field").prop("disabled", false);
		}
		id_field_is_active = !id_field_is_active;
    })
})

