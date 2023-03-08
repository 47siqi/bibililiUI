<template>
    <div>
        <!-- 视频播放器的容器 -->
        <div id="mui-player">
            <!-- <slot name="nextMedia">
                <svg t="1584686776454" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg"
                    p-id="1682" width="22" height="22">
                    <path
                        d="M783.14692466 563.21664097L240.85307534 879.55472126c-39.1656664 24.10194914-90.38230866-6.02548665-90.38230865-51.21664226v-632.676158c0-45.19115433 51.21664097-75.31859011 90.38230865-51.21664226l542.29384932 316.33808029c39.1656664 21.08920518 39.1656664 81.34407804 0 102.43328194z"
                        p-id="1683" fill="#ffffff"></path>
                    <path
                        d="M873.52923331 734.94302767c0 42.17841036-39.1656664 78.33133408-90.38230865 78.33133407s-90.38230866-36.15292371-90.38230735-78.33133407V289.05697233c0-42.17841036 39.1656664-78.33133408 90.38230735-78.33133407s90.38230866 36.15292371 90.38230865 78.33133407v445.88605534z"
                        p-id="1684" fill="#ffffff"></path>
                </svg>
            </slot> -->
        </div>
        <!-- 左侧脚部控件 -->
        <div id="LeftFootCom">
            //下一集按钮控件
            <button v-show="customControls.footer.left.nextMedia" id="nextMedia" title="下一集">
                <svg t="1584686776454" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg"
                    p-id="1682" width="22" height="22">
                    <path
                        d="M783.14692466 563.21664097L240.85307534 879.55472126c-39.1656664 24.10194914-90.38230866-6.02548665-90.38230865-51.21664226v-632.676158c0-45.19115433 51.21664097-75.31859011 90.38230865-51.21664226l542.29384932 316.33808029c39.1656664 21.08920518 39.1656664 81.34407804 0 102.43328194z"
                        p-id="1683" fill="#ffffff"></path>
                    <path
                        d="M873.52923331 734.94302767c0 42.17841036-39.1656664 78.33133408-90.38230865 78.33133407s-90.38230866-36.15292371-90.38230735-78.33133407V289.05697233c0-42.17841036 39.1656664-78.33133408 90.38230735-78.33133407s90.38230866 36.15292371 90.38230865 78.33133407v445.88605534z"
                        p-id="1684" fill="#ffffff"></path>
                </svg>
            </button>
        </div>
        <!-- 右侧脚部控件 -->
        <div id="RightFootCom"> 
            <!-- 弹幕设置图标 -->
            <button class="player-but ">

            </button>
        </div>
    </div>
</template>
<script>
import 'mui-player/dist/mui-player.min.css'
import MuiPlayer from 'mui-player'
import MuiPlayerDesktopPlugin from 'mui-player-desktop-plugin'
export default {
    name: "MuiPlayer",
    data: () => ({
        customControls:{
            footer :{
                left:{
                    nextMedia:true  //下一集控件是否显示
                }
            }
        },
        config: {
            container: '#mui-player',   //容器
            title: 'Java从入门到入坟',
            src: 'http://v.itheima.com/20天学会java/01、Java课程简介.mp4',
            plugins: [
                new MuiPlayerDesktopPlugin({
                    // customSetting, // 设置组配置
                    // contextmenu, // 右键菜单组配置
                    // thumbnails,  // 缩略图配置
                })
            ],
        }
    }),
    mounted() {
        // 初始化 MuiPlayer 插件，MuiPlayer 方法传递一个对象，该对象包括所有插件的配置
        var mp = new MuiPlayer(this.config)
        //创建监听播放器
        mp.on('ready', event => {
            //获取底部左侧控件
            let leftPart = document.getElementById('left-part')
            //时间节点
            let timeNode = leftPart.childNodes[1]
            //下一集控件
            let nextMedia = document.getElementById('nextMedia')
            leftPart.insertBefore(nextMedia,timeNode)
            console.log(event);
        })
    }
}
</script>

<style>
#nextMedia , .progress {
    background-color: transparent !important;
    border:0px
}
</style>