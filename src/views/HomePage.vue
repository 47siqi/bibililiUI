<template>
  <div>
    <!-- <el-carousel height="450px" v-if="isShow">
            <el-carousel-item v-for="item in images" :key="item">
                <el-link :href="item.courseUrl" target="_blank">
                    <el-image :src="item.imageUrl"></el-image>
                </el-link>
            </el-carousel-item>
        </el-carousel> -->
    <el-carousel :interval="4000" type="card" height="250px">
      <el-carousel-item v-for="item in images" :key="item">
        <el-image :src="item.imageUrl"></el-image>
      </el-carousel-item>
    </el-carousel>

    

  </div>
  <HomeContent />
</template> 
<script setup>
import { ref, onMounted } from 'vue'
// 导入获取轮播图的方法
import { getBanners2 } from '../http/index'
import HomeContent from "../components/HomeContent.vue";
const images = ref();
const isShow = ref(false);
// images.value = [
//     {
//         'imageUrl': '/imgages/banners/21_birthday_banner_pc',
//         'courseUrl': 'http://localhost:8080/'
//     },
//     {
//         'imageUrl': '/imgages/banners/21_brand_banner_pc',
//         'courseUrl': 'http://localhost:8080/'
//     },
//     {
//         'imageUrl': '/imgages/banners/21_syz_banner_pc',
//         'courseUrl': 'http://localhost:8080/'
//     }
// ]

onMounted(async () => {
  images.value = (await getBanners2()).data
  isShow.value = true;
})

</script>

<style lang="scss">
// .el-carousel__container {
//     height: 300px !important;
//     margin-top: 10px;
// }
.el-tag {
  margin-right: 10px;
}

.el-row {
  margin-bottom: 20px;

  &:last-child {
    margin-bottom: 0;
  }
}

.el-col {
  border-radius: 4px;
}

.bg-purple-dark {
  background: #99a9bf;
}

.bg-purple {
  background: #d3dce6;
}

.bg-purple-light {
  background: #e5e9f2;
}

.grid-content {
  border-radius: 4px;
  min-height: 36px;
}

.row-bg {
  padding: 10px 0;
  background-color: #f9fafc;
}
</style>