<script setup lang="ts">
import WelcomeItem from "../../../components/WelcomeItem.vue";
import DocumentationIcon from "../../../components/icons/IconDocumentation.vue";
import ToolingIcon from "../../../components/icons/IconTooling.vue";
import EcosystemIcon from "../../../components/icons/IconEcosystem.vue";
import CommunityIcon from "../../../components/icons/IconCommunity.vue";
import SupportIcon from "../../../components/icons/IconSupport.vue";
import { UserTypeEnum } from "@/enum/user-type-enum";
import io from "socket.io-client";

import _ from "lodash";
</script>
<script lang="ts">
const socket = io("http://34.172.211.20:3000");

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
    handleSubmit(e: any) {
      console.log("訊息發送！！！");
      console.log("名字：", this.displayName);
      console.log("訊息：", this.text);
      if (_.isEmpty(this.displayName)) {
        alert("請輸入名字");
      } else {
        this.data.push({
          displayName: this.displayName ? this.displayName : "無名氏",
          userType: this.userType,
          text: this.text,
        });
        socket.emit("send_Msg", {
          displayName: this.displayName ? this.displayName : "無名氏",
          userType: this.userType,
          text: this.text,
        });

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
