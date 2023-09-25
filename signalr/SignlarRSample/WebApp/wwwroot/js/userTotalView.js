const connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hub/usersCount").build();

connectionUserCount.on("updateTotalViews", (value) => {
    const newCountSpan = document.getElementById("totalViewsCount");
    newCountSpan.innerText = value.toString();
});
connectionUserCount.on("updateTotalUsers", (value) => {
    const newCountSpan = document.getElementById("totalUsersCount");
    newCountSpan.innerText = value.toString();
});

function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoadedAsync");
}

function fulfilled() {
    console.log("connection to user hub");
    newWindowLoadedOnClient();
}
function rejected() {
    console.warn("error");
}

connectionUserCount.start().then(fulfilled, rejected);