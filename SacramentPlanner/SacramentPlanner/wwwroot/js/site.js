// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#myBtn1").click(function () {
        $("#myModal1").modal();
    });
});
$(document).ready(function () {
    $("#myBtn2").click(function () {
        $("#myModal2").modal();
    });
});
$(document).ready(function () {
    $("#myBtn3").click(function () {
        $("#myModal3").modal();
    });
});
$(document).ready(function () {
    $("#speakers_table_button").click(function () {
        console.log("Called")
        var table = document.getElementById("speakers_table")
        var table_html = "<tr><th>Speaker's Name</th><th>Speakers' Topic</th><th></th></tr>"
        var memberSelect = document.getElementById("speakers_table_member")
        var topicText = document.getElementById("speakers_table_text")
        var jsonInput = document.getElementById("speaker_string")
        if (jsonInput.value == null || jsonInput.value == "") {
            var jsonObject = []
        } else {
            var jsonObject = JSON.parse(jsonInput.value)
        }
        jsonObject.push({
            "memberId": memberSelect.options[memberSelect.selectedIndex].value,
            "memberName": memberSelect.options[memberSelect.selectedIndex].text,
            "topic": topicText.value
        })
        index = 0
        for (var speaker in jsonObject) {
            table_html = table_html + `<tr><td>${jsonObject[speaker].memberName}</td><td>${jsonObject[speaker].topic}</td><td><button type="button" onclick="removeSpeaker(${index})">Remove</button></td></tr>`
            index += 1
        }
        memberSelect.selectedIndex = 0
        topicText.value = ""
        jsonInput.value = JSON.stringify(jsonObject)
        table.innerHTML = table_html
    });
});

function removeSpeaker(fInput) {
    var table = document.getElementById("speakers_table")
    var table_html = "<tr><th>Speaker's Name</th><th>Speakers' Topic</th></tr>"
    var jsonInput = document.getElementById("speaker_string")
    if (jsonInput.value == null || jsonInput.value == "") {
        var jsonObject = []
    } else {
        var jsonObject = JSON.parse(jsonInput.value)
        jsonObject.splice(fInput, 1)
    }
    index = 0
    for (var speaker in jsonObject) {
        table_html = table_html + `<tr><td>${jsonObject[speaker].memberName}</td><td>${jsonObject[speaker].topic}</td><td><button type="button" onclick="removeSpeaker(${index})">Remove</button></td></tr>`
        index += 1
    }
    jsonInput.value = JSON.stringify(jsonObject)
    table.innerHTML = table_html
}