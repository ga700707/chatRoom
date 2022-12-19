<!-- <template>
  <a-timeline mode="">
    <a-timeline-item>
      <template #dot>
        <ClockCircleOutlined style="font-size: 16px" />
      </template>
      <p>2022/12/19</p>
      <p>引入Antd UI框架</p>
      <p>About調整</p>
    </a-timeline-item>

    <a-timeline-item>
      <template #dot>
        <ClockCircleOutlined style="font-size: 16px" />
      </template>
      <p>2022/12/18</p>
      <p>tailwind引入</p>
      <p>socketIO串接</p>
      <p>後端API建置</p>
      <p>Google GCP 雲端</p>
      <p>Google GCP SQL</p>
      <p>聊天室架構完成</p>
    </a-timeline-item>

    <a-timeline-item>
      <template #dot>
        <ClockCircleOutlined style="font-size: 16px" />
      </template>
      <p>2022/12/17</p>
      <p>聊天室專案建置</p>
      <p>引用vue</p>
      <p>typescript聊天室UI設計</p>
    </a-timeline-item>

  </a-timeline>
</template>

<script lang="ts">
import { ClockCircleOutlined } from '@ant-design/icons-vue';
import { defineComponent } from 'vue';
export default defineComponent({
  components: {
    ClockCircleOutlined,
  },
});
</script>
<style> -->


<template>
  <a-timeline mode="">
    <a-timeline-item v-for="(item2, index) in data">
      <template #dot>
        <ClockCircleOutlined style="font-size: 16px" />
      </template>
      <h3 :style="{ margin: '16px 0' }">{{ item2.title }}</h3>
      <a-list size="small" bordered :data-source="item2.description">
        <template #renderItem="{ item }">
          <a-list-item>
            <a-list-item-meta>
              <template #description>
                <a>{{ item }}</a>
              </template>
            </a-list-item-meta>
          </a-list-item>
        </template>
      </a-list>
    </a-timeline-item>
  </a-timeline>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { ClockCircleOutlined } from '@ant-design/icons-vue';
interface DataItem {
  title: string;
  description: string[];
}
const data: DataItem[] = [
  {
    title: '2022/12/19',
    description: [
      "引入Antd UI框架",
      "About調整",
    ]
  },
  {
    title: '2022/12/18',
    description: [
      "tailwind引入",
      "socketIO串接",
      "後端API建置",
      "Google GCP 雲端",
      "Google GCP SQL",
      "聊天室架構完成",
    ]
  },
  {
    title: '2022/12/17',
    description: [
      "聊天室專案建置",
      "引用vue",
      "typescript聊天室UI設計",
    ]
  }
];
export default defineComponent({
  setup() {
    return {
      data,
    };
  },
  components: {
    ClockCircleOutlined,
  },
});
</script>
