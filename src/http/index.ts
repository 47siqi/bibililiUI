import axios from 'axios';
import { ref } from 'vue'
//需要拦截器的地方使用instance对象， 有自定义返回逻辑的地方沿用axios，在组件内部处理返回结果即可
import instance from './filter'
//获取首页Banner轮播图
const json = ref("/json")
const http = ref("https://localhost:7210/api")
export const getBanners = () => {
    return axios.get(json.value + "/banner.json");
}
//轮播图图片
export const getBanners2 = () => {
    return axios.get(http.value + "/Image/GetImages"); 
}
export const getFenLei = () => {
    return axios.get(http.value + "/FenLei/GetFenLei"); 
}

export const getFlowers = (parms: {}) => {
    return axios.post(http.value + "/Flower/GetFlowers",parms); 
}

export const getFlieCard = (parms: {}) => {
    return axios.post(http.value + "/FlieCard/GetFlieCard",parms); 
}

export const getBingeWatch = (parms: {}) => {
    return axios.post(http.value + "/BingeWatch/GetBingeWatch",parms); 
}

//注册
export const Register = (parms: {}) => {
    return axios.post(http.value + "/Login/Register", parms); 
}
//登录
export const getToken = (parms: {}) => {
    return axios.post(http.value + "/Login/Check", parms); 
}
//验证码
export const getValidateCode = () =>{
    return axios.get(http.value +"/Login/GetValidateCodeImages?t=");
}

//生成一笔订单
export const CreateOrder = (parms: {}) => {
    //在header里携带token访问后端接口
    axios.defaults.headers.common['Authorization'] = "Bearer " + localStorage["token"];
    return axios.post(http.value + "/Order/CreateOrder", parms);
}
//获取订单列表
export const GetOrder = () => {
    //在header里携带token访问后端接口
    instance.defaults.headers.common['Authorization'] = "Bearer " + localStorage["token"];
    return instance.post(http.value + "/Order/GetOrder");
}