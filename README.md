# Google 雲端測試位置

```sh
http://34.172.211.20
```

### tailwindcss

```sh
npm install postcss-import
npm install postcss-nesting
npm install -D postcss-nesting
npx tailwindcss -i ./src/style.scss -o ./dist/output.css --watch
```

### Pm2 - SocketIO

```sh
sudo npm install pm2 -g
sudo pm2 start "node index.js"
sudo pm2 start "dotnet ctest_api.dll"
```

### Starter

https://blog.bitsrc.io/6-best-ways-to-create-a-new-react-application-57b17e5d331a
https://github.com/vercel/next.js/tree/canary/examples/with-typescript-graphql

## 開發日誌
### Day 01 - 2022/12/17
聊天室專案建置
引用 vue
typescript 聊天室 UI 設計

### Day 02 - 2022/12/18
tailwind 引入
socketIO 串接
後端 API 建置
Google GCP 雲端
Google GCP SQL
聊天室架構完成

### Day 03 - 2022/12/19
引入 Antd UI 框架
About 調整

### Day 04 - 2022/12/23 (未來架構重新規劃) 
前期架構: 
資料庫: AWS DynamoDB
後端: Golang + gitlab
後端 GraphQL: gqlgen (參考資料: https://ithelp.ithome.com.tw/articles/10213118)
前端: next.js + react + GraphQL + vercel
SocketIO server: node.js
後期架構:
app: Flutter + GraphQL 

