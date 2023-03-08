<template>
    <div class="common-layout">
        <el-container>
            <el-header>
                <div class="hd">
                    <h3>
                        <a href="/loveflower">推荐好番</a>
                    </h3>
                </div>
            </el-header>
            <el-row :gutter="20">
                <!-- 分类 -->
                <el-col :span="16">
                    <div class="grid-content bg-purple">

                        <tbody>
                            <tr>
                                <th style="width: 70px;">分类</th>
                                <td>
                                    <el-tag type="info" color="transpaarent" v-for="itemtag in FenLei" :key="itemtag">{{
                                        itemtag.fenLeiTag }}</el-tag>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 70px;">类型</th>
                                <td>
                                    <el-tag type="info" color="transpaarent" v-for="itemtag in FenLei" :key="itemtag">{{
                                        itemtag.fenLeiTag }}</el-tag>
                                </td>
                            </tr>

                        </tbody>

                        <br><br>
                        <!-- getFlieCard -->
                        <el-main>
                            <div class="fl-products">
                                <div class="fl-products-item" v-for="itemCard in listCard" :key="itemCard">
                                    <router-link  :to="'./VideoPlayCom'">
                                        <div class="img-box" style="line-height: 0;">
                                            <el-image style="width: 150px; height: 200px" :src="itemCard.pic" />
                                        </div>
                                        <div class="product-content">
                                            <p class="product-sub">
                                                <span class="price-num">{{ itemCard.title }}</span>
                                            </p>
                                            <p class="product-title">{{ itemCard.subTitle }}</p>
                                        </div>
                                    </router-link>
                                </div>
                            </div>
                        </el-main>
                    </div>

                </el-col>
                <!-- 追剧 -->
                <el-col :span="8">
                    <div class="grid-content bg-purple">
                        <br>
                        在追剧
                        <br><br>
                        <BingeWatch></BingeWatch>
                        
                    </div>
                </el-col>
            </el-row>

        </el-container>
    </div>
</template> 

<script setup>
import { getFenLei, getFlieCard} from '../http/index'
import { ref, onMounted } from 'vue'
import BingeWatch from './BingeWatch.vue'
const FenLei = ref();
const isShow = ref(false);
//响应式变量
const listCard = ref();
onMounted(async () => {
    FenLei.value = (await getFenLei()).data
    isShow.value = true;
})

onMounted(async () => {
    // 请求后端接口
    let parms = {
        Id: 0,
    }
    listCard.value = (await getFlieCard(parms)).data.result
    //console.log(getFlieCard(parms))
})

</script>

<style lang="scss">
.common-layout {
    padding-left: 80px;
    background-color: #f7f9fa;
}
.el-main{
    line-height: 0;
}
.more {
    font-size: 15px;
    line-height: 30px;
    color: rgb(161, 161, 161);
    float: right;
    margin-right: 21%;
}

.hd {
    text-align: initial;

    h3 {
        font-size: 26px;
        line-height: 30px;
        color: #232628;
        font-weight: bold;

        a {
            color: rgb(161, 161, 161)
        }

        span {
            padding-left: 15px;
            margin-left: 16px;
            font-size: 20px;
            line-height: 24px;
            font-weight: normal;
            border-left: 1px solid #71797f;
        }
    }
}

.common-layout {
    background-color: rgb(20, 20, 20)
}

.fl-products {
    vertical-align: top;

    .fl-products-item {
        display: inline-block;
        width: 150px;
        margin-left: 16px;
        margin-bottom: 16px;
        background-color: #fff;
        vertical-align: top;

        .product-content {
            padding: 10px 8px 14px;
            text-align: center;
            color: white;
            background-color: rgb(20, 20, 20);

            .product-title {
                max-width: 100%;
                overflow: hidden;
                -o-text-overflow: ellipsis;
                text-overflow: ellipsis;
                white-space: nowrap;
                font-size: 12px;
                line-height: 20px;
            }

            .product-sub {
                margin-top: 5px;
                font-size: 14px;
                font-weight: bold;
                line-height: 20px;
            }
        }
    }
}
</style>