# adventure

# 前言
 在学习游戏编程模式之前，我写的许多unity小项目都只是基于组件+加简单的脚本逻辑去实现的。
 当我在想要开发一款横版2D冒险游戏的时候，根据以往的游戏经验，主角一般至少拥有以下几种行为：站立，行走，跑动，跳跃，攻击。那么在开始编写一个脚本来处理玩家的输入时，就会出现类似下面的代码：
```
 void handleInput(Input input){
     if(input == PRESS_D){
         //move to right
     }
     else if(input == PRESS_A){
         //move to left
     }
     else if(input == PRESS_SPACE){
         //jump
     }
 }
```
当然，以上代码仅仅用来控制角色移动是没有问题的，但是游戏往往在角色不同运动状态时会有不一样的贴图（或者是动画），所以代码如下：
```
 void handleInput(Input input){
     if(input == PRESS_D){
         //move to right
         //set graphics move
     }
     else if(input == PRESS_A){
         //move to left
         //set graphics move
     }
     else if(input == PRESS_SPACE){
         //jump
         //set graphics jump
     }
     else{
         //set graphics idle
     }
 }
```
