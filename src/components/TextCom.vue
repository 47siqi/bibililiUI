<!-- <template>
    <div>
        城市：<input type="text" v-model="cityCode">
        <button @click="getCityWeather">查询天气</button>
    </div>
</template>

<script setup>
    import {ref } from 'vue'
    import axios from 'axios';
    const cityCode = ref(null)//城市ID
    const cityWeather = ref(null) //城市的天气状况
    function getCityWeather(){
        //发送请求
        axios({
            method:'GET',//请求方式
            url:'https://eolink.o.apispace.com/456456/weather/v001/now',
            //请求头
            headers:{
                'X-APISpace-Token':'p6kqnj687u8k22vl2xfvnw58ocm1qwy9',  //鉴权私钥
                'Authorization-Type':'apikey'
            },
            params:{"areacode":cityCode.value}
        }).then(response =>{  //获取服务器响应数据
            const responseData = response.data  //服务器返回的数据
            console.log(responseData);
            if(responseData.status === 0){
                //查询成功
                cityWeather.value = responseData.result
            }else{
                alert(responseData.message)
            }
        })

    }
</script>

<style></style> -->