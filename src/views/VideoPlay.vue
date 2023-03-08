<template>
  <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
  <div class="videoMain">
    <div class="header">
      <h5 class="videoTitle">这是一个测试视频</h5>
      <span class="subVideoTitle">
        <!-- 播放量 -->
        <i class="glyphicon glyphicon-play-circle" style="font-size: 14px;">
          <span>1211</span>
        </i>
        <!-- 弹幕量 -->
        <i class="glyphicon glyphicon-align-center" style="font-size: 14px;">
          <span>345</span>
        </i>
        <i class="glyphicon glyphicon-time" style="font-size: 14px;">
          <span>2023-2-18</span>
        </i>
        <i class="glyphicon glyphicon-ban-circle" style="font-size: 14px; color: red;">
          <span style="color:#e9eef3">未经作者授权,禁止转载</span>
        </i>
      </span>
    </div>
    <el-container>
      <el-main>
        <!-- 视频播放器 -->
        <mui-player></mui-player>
      </el-main>
      <el-aside width="200px">选集、猜你喜欢</el-aside>
    </el-container>
  </div>
</template>

<script>
import MuiPlayer from '@/components/MuiPlayer.vue';
export default {
  name: 'VideoPlayCom',
  props: ['id'],
  components:{MuiPlayer}
}
</script>

<style>
.videoMain {
  min-width: 1100px;
  max-width: 1100px;
  margin: 0px auto;
}

.videoTitle {
  margin: auto;
  font-size: 16px;
  display: flex;
}

i {
  margin-right: 15px;
}

.subVideoTitle {
  margin-top: 10px;
  font-size: 16px;
  display: flex;

  /* color: #D3DCE6; */
}

.header {
  background-color: #B3C0D1;
  color: #333;
  text-align: center;
  line-height: 30px;
  padding-left: 50px;
}

.el-aside {
  background-color: #D3DCE6;
  color: #333;
  text-align: center;
  line-height: 200px;
  min-width: 300px;
  max-width: 300px;
}

.el-main {
  background-color: #E9EEF3;
  color: #333;
  text-align: center;
  /* line-height: 160px; */
}
</style>