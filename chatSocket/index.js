const express = require("express");
const { Server } = require("socket.io");
var cors = require("cors");
const app = express();
const http = require("http");
const server = http.createServer(app);
app.use(cors());
app.get("/", (req, res) => {
  res.send("<h1>Hello world</h1>");
});

const io = new Server(server, {
  allowEIO3: true,
  cors: {
    origin: ["http://localhost:5173","http://34.172.211.20"],
    credentials: true,
  },
});

io.on("connection", (socket) => {
  console.log("connection");
  //   socket.on("send", function (obj) {
  //     console.log(obj.msg);

  //     socket.broadcast.emit("other", {
  //       msg: obj.msg,
  //     });
  //     socket.emit("self", {
  //       msg: obj.msg,
  //     });
  //   });
  socket.on("send_Msg", function (obj) {
    console.log(obj);
    socket.broadcast.emit("receive_Msg", obj);
    // socket.emit("receiveMsg", obj);
  });
});

server.listen(3000,() => {
  console.log("listening on *:3000");
});
