let searchPosts = () => {
    var _data = {
        keyword: $("#keyword").val()
    };
    console.log("searching...");
    $.ajax({
        url: '/Home/Search',
        type: "POST",
        data: JSON.stringify(_data),
        contentType: "application/json",
        dataType: "html",
        success: (results) => {
            $("#resutls").html(results);
        }
    });
}