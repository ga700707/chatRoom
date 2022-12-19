<script setup lang="ts">
import WelcomeItem from "../../../components/WelcomeItem.vue";
import DocumentationIcon from "../../../components/icons/IconDocumentation.vue";
import ToolingIcon from "../../../components/icons/IconTooling.vue";
import EcosystemIcon from "../../../components/icons/IconEcosystem.vue";
import CommunityIcon from "../../../components/icons/IconCommunity.vue";
import SupportIcon from "../../../components/icons/IconSupport.vue";
import { UserTypeEnum } from "@/enum/user-type-enum";
import io from "socket.io-client";
import axios from "axios";
import { inject } from "vue";
import _ from "lodash";
</script>
<script lang="ts">
const ip = "http://34.172.211.20";
const socket = io(ip + ":3000");
const apiUrl = ip + ":5000";
export default {
  sockets: {
    connect: function () {
      console.log("socket connected");
    },
  },
  data() {
    return {
      displayName: "",
      userType: UserTypeEnum.發送者,
      text: "",
      count: 0,
      data: [
        {
          displayName: "路人1",
          userType: UserTypeEnum.接收者,
          text: "BText",
        },
        {
          displayName: "路人2",
          userType: UserTypeEnum.發送者,
          text: "CText",
        },
        {
          displayName: "路人3",
          userType: UserTypeEnum.發送者,
          text: "AText",
        },
      ],
    };
  },
  mounted() {
    this.getAllLog();
    socket.on("receive_Msg", (obj) => {
      if (this.displayName != obj.displayName) {
        this.data.push({
          displayName: obj.displayName,
          userType: UserTypeEnum.接收者,
          text: obj.text,
        });
        this.$nextTick(() => {
          if (this.$refs.msgContainer) {
            (this.$refs.msgContainer as any).scrollTop = (
              this.$refs.msgContainer as any
            ).scrollHeight;
          }
        });
      }
    });
  },
  methods: {
    getAllLog() {
      axios
        .post(apiUrl + "/room/GetAll", {})
        .then((response: { data: any }) => {
          console.log(response);
          if (response.data && response.data.length > 0)
            response.data.forEach((log: any) => {
              this.data.push(log);
            });
          this.$nextTick(() => {
            if (this.$refs.msgContainer) {
              (this.$refs.msgContainer as any).scrollTop = (
                this.$refs.msgContainer as any
              ).scrollHeight;
            }
          });
        });
    },
    createLog(param: any) {
      axios
        .post(apiUrl + "/room/Create", param)
        .then((response: { data: any }) => {
          console.log(response);
        });
    },

    handleSubmit(e: any) {
      console.log("訊息發送！！！");
      console.log("名字：", this.displayName);
      console.log("訊息：", this.text);
      if (_.isEmpty(this.displayName)) {
        alert("請輸入名字");
      } else {
        let chatlog = {
          displayName: this.displayName ? this.displayName : "無名氏",
          userType: this.userType,
          text: this.text,
        };
        this.data.push(chatlog);
        this.createLog(chatlog);
        socket.emit("send_Msg", chatlog);

        this.text = "";
        this.$nextTick(() => {
          if (this.$refs.msgContainer) {
            (this.$refs.msgContainer as any).scrollTop = (
              this.$refs.msgContainer as any
            ).scrollHeight;
          }
        });
      }

      e.prevent;
    },
  },
};
</script>

<template class="chatroom">
  <form class="chatroom_block chatroom" @submit.prevent="handleSubmit">
    <input
      placeholder="請輸入姓名:"
      class="chatroom_name-input"
      id="displayName"
      type="text"
      v-model="displayName"
    />
    <input
      placeholder="瀏覽人數:"
      class="chatroom_people-count"
      id="count"
      type="text"
      v-model="count"
    />

    <div class="chatroom_title-block text-2xl text-center">
      <span>聊天室</span>
    </div>
    <div ref="msgContainer" class="chatroom_content">
      <div class="chatroom_text" v-for="(item, index) in data">
        <span
          :class="[
            item.userType == UserTypeEnum.發送者 ? 'sendMsg' : 'receiveMsg',
          ]"
        >
          {{ item.displayName }}: {{ item.text }}
        </span>
      </div>
    </div>

    <input id="text" type="text" v-model="text" class="chatroom_input pl-2" />
    <input class="sendBtn cus-btn" type="submit" value="送出" />
  </form>
</template>
