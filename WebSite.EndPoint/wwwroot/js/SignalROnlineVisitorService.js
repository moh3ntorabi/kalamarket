var connection = new SignalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .build();

connection.start();