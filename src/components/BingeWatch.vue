<template>
    <div>
        <div v-for="itemCard in BingeWatch" :key="itemCard">
            <a>
                <div>
                    <el-image style="width: 250px; height: 150px" :src="itemCard.pic" />
                </div>
                <div class="Biaoti">
                    <p class="Bigtitle">
                        {{ itemCard.title }}
                    </p>
                    
                    <span class="subtitle">{{ itemCard.subTitle }}</span>
                </div>
            </a>
        </div>
    </div>
</template>

<script setup>
import { getBingeWatch } from '@/http'
import { onMounted, ref } from 'vue'
const BingeWatch = ref();
onMounted(async ()=>{
    let parms = {
        Id: 0,
    }
    BingeWatch.value = (await getBingeWatch(parms)).data.result
})
</script>

<style>
.Bigtitle{
    font-size: 16px;
    margin: 0px;
}
.Biaoti{
    margin-bottom: 20px;
}
</style>