<template>
  <div id="footer" class="ft">
    <div class="ft-container">
    
      <!-- 尾部导航 啊啊啊啊啊 -->
      <div class="ft-nav">
        <a href="/">首页</a>
        <a href="https://www.bilibili.com/" target="_blank">关于我们</a>
      </div>
      <!-- 尾部导航 End -->
      <!-- 友情链接 -->
      <div class="ft-link">
        <span>友链</span>
        <a href="https://ke.qq.com/" target="_blank">腾讯课堂</a>
      </div>
      <!-- 友情链接 End -->
    </div>
  </div>
</template>

<script lang="ts" setup> 
</script>

<style lang="scss">
#footer {
  font-size: 0;
  background-color: #232628;
  .ft-container {
    width: 1200px;
    margin: 0 auto;
    padding: 40px 0 46px;
    .ft-nav {
      a {
        display: inline-block;
        font-size: 16px;
        line-height: 16px;
        color: #fff;
      }
      a + a {
        padding-left: 28px;
        margin-left: 33px;
        border-left: 1px solid #fff;
      }
    }
    .ft-link {
      margin-top: 20px; 
      span {
        font-size: 12px;
        line-height: 16px;
        margin-right: 4px;
        font-weight: bold;
        color: #71797f;
      }
      a {
        font-size: 12px;
        line-height: 16px;
        color: #71797f;
        margin: 0 2px;
      }
    }
  }
}
</style>
