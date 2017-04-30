let upVote = (postId) => {
    let _data = {
        id: postId
    };

    $.ajax({
        url: "/home/countup",
        data: JSON.stringify(_data),
        contentType: "application/json",
        type: "POST",
        dataType: "html",
        success: (newHtml) => {
            $("#voteContainer-" + postId).html(newHtml);
        }
    })
};

let downVote = (postId) => {
    let _data = {
        id: postId
    };

    $.ajax({
        url: "/home/countdown",
        data: JSON.stringify(_data),
        contentType: "application/json",
        type: "POST",
        dataType: "html",
        success: (newHtml) => {
            $("#voteContainer-" + postId).html(newHtml);
        }
    })
};
