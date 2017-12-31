var post = function (id, message, username, date) {
    this.id = id;
    this.message = message;
    this.username = username;
    this.date = date;
    this.comments = ko.observableArray([]);

    this.addComment = function (context) {
        var comment = $('input[name="comment"]', context).val();
        if (comment.length > 0) {
            $.connection.boardHub.server.addComment(this.id, comment, vm.username())
            .done(function () {
                $('input[name="comment"]', context).val('');
            });
        }
    };
}

var comment = function (id, message, username, date) {
    this.id = id;
    this.message = message;
    this.username = username;
    this.date = date;
}

var vm = {
    posts: ko.observableArray([]),
    notifications: ko.observableArray([]),
    username: ko.observable(),
    signedIn: ko.observable(false),
    signIn: function () {
        vm.username($('#username').val());
        vm.signedIn(true);
    },
    writePost: function () {
        $.connection.boardHub.server.writePost(vm.username(), $('#message').val()).done(function () {
            $('#message').val('');
        });
    },
}

ko.applyBindings(vm);

function loadPosts() {
    $.get('/api/posts', function (data) {
        var postsArray = [];
        $.each(data, function (i, p) {
            var newPost = new post(p.Id, p.Message, p.Username, p.DatePosted);
            $.each(p.Comments, function (j, c) {
                var newComment = new comment(c.Id, c.Message, c.Username, c.DatePosted);
                newPost.comments.push(newComment);
            });

            vm.posts.push(newPost);
        });
    });
}

$(function () {
    var hub = $.connection.boardHub;
    $.connection.hub.start().done(function () {
        loadPosts(); // Load posts when connected to hub
    });

    // Hub calls this after a new post has been added
    hub.client.receivedNewPost = function (id, username, message, date) {
        var newPost = new post(id, message, username, date);
        vm.posts.unshift(newPost);

        // If another user added a new post, add it to the activity summary
        if (username !== vm.username()) {
            vm.notifications.unshift(username + ' has added a new post.');
        }
    };

    // Hub calls this after a new comment has been added
    hub.client.receivedNewComment = function (parentPostId, commentId, message, username, date) {
        // Find the post object in the observable array of posts
        var postFilter = $.grep(vm.posts(), function (p) {
            return p.id === parentPostId;
        });
        var thisPost = postFilter[0]; //$.grep returns an array, we just want the first object

        var thisComment = new comment(commentId, message, username, date);
        thisPost.comments.push(thisComment);

        if (thisPost.username === vm.username() && thisComment.username !== vm.username()) {
            vm.notifications.unshift(username + ' has commented on your post.');
        }
    };
});