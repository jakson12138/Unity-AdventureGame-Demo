# adventure

## 1、前言
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
显然，上面的代码是有错误的，比如在跳跃的时候按下移动键，角色没落地前，角色应该还是跳跃的贴图，而当玩家没有输入时，也不应该立即转化为站立的贴图，而是在玩家落地时改变，所以代码需要加入一个bool变量isJumping：
```
 void handleInput(Input input){
     if(input == PRESS_D){
         //move to right
         if(!isJumping) //set graphics move
     }
     else if(input == PRESS_A){
         //move to left
         if(!isJumping) //set graphics move
     }
     else if(input == PRESS_SPACE){
         //jump
         //set graphics jump
         isJumping = true;
     }
     else{
         if(!isJumping) //set graphics idle
     }
 }
```
并在物理引擎中在角色落地时将isJumping修改为false。  
然后我们就会发现，代码不支持角色二段跳，或者我们想要给角色加入不同的行走状态（比如跑步），再加上一个攻击状态呢？如果依旧像上面那样用很多个if...else语句以及bool变量去处理玩家输入的话，代码将会非常臃肿并且难以维护（当出现bug时去修改某个状态时，可能牵一发而动全身），所以当我在《游戏编程模式》看到状态模式时，欣喜若狂，因为这恰恰帮我解决了之前一直困扰我的问题。

## 2、尝试
在状态模式中，分别介绍了几种方法，包括**有限状态机**、**并发状态机**、**层次状态机**以及**下推状态机**。为了完成简单的几种状态转化，我这里只实现了最简单的有限状态机。
### 2.1、状态与行为
使用有限状态机的情况一般拥有以下几个特点：  
a、你拥有一组状态，并且可以在这组状态之间进行切换  
b、状态机同一时刻只能处于一个状态  
c、状态机会接收一组输入或者事件  
d、每一个状态有一组转换，每一个转换都关联着一个输入并指向另一个状态  
在我们这次的例子中，我们需要处理的有5个状态：站立，行走，跑动，跳跃，攻击；需要处理的行为便是键盘的输入。

### 2.2、状态的表示
#### 2.2.1、枚举状态
我们的有限状态机的每一个状态可以用一个枚举来表示，比如我们定义如下枚举：
```
enum PlayerState{
    IdleState,
    WalkState,
    RunState,
    JumpState,
    AttackState
}
```
然后在输入处理代码中，我们用以下格式来处理每个状态:
```
switch(playerState){
    case IdleState:
        if(input == PRESS_D){
            playerState = WalkState;
            //move to right
            //set graphics walk
        }
        else ...
        break;
    case WalkState:
        ...
        break;
    case ...
}
```
这样看起来很普通，但是它却是对前面的代码的一个提升，我们仍然有一些升级条件分支语句，但是我们简化了状态的处理。这是实现状态机最简单的方法，在某些情况下，这是一种不错的解决方法。  
现在假设我们要实现一个蓄能攻击的效果，在攻击状态时按住攻击键进行蓄能，蓄满能量我们能发出一个特殊技能。依旧使用枚举的方法，我们可以在主角类中加入一个energy来保存蓄能的多少，然后在AttackState中持续增加energy的值，当松开攻击键时使用技能并改变状态。  
对于一个简单的游戏来讲，这种方式的确可行，但当你的攻击方式变得多样，你可能需要保存更多的变量，其他状态也可能需要属于自己的变量而不是将其放在主角类中，此时，我们需要的其实想把所有与状态有关的数据和代码封装起来，这也是GoF的状态模式的做法。
#### 2.2.2、为每一个状态定义一个类
对于每一个状态，我们定义一个类来封装其需要保存的数据以及处理的行为，在此之前我们需要定义一个基类：
```
class PlayerState{
    
    virtual void Update(Player player){
    
    }
    
    virtual void HandleInput(Player player){
    
    }
    
};
```
