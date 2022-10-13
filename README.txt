README

108703051 謝惟寧


遊戲操作：
A: 左
D: 右
SPACE: 跳

遊戲機制：
玩家擔任小紅人，需要在類瑪利歐世界裡，賺取金幣。
(金幣設了2層collider2D，一個有trigger另個沒有，可以使金幣不會從平台掉落，並被主角碰撞)
但是需要小心空中錘錨掉落，小紅人只有3條生命，藉由碰撞偵測，撞一次扣一條命。
(錘錨是由垂苗生產者在隨機時間隨機座標產生，碰到地面或河流後，2秒內自我摧毀)
最後，若主角掉到河內，則遊戲直接結束。

遊戲素材出處(含版權)：
https://assetstore.unity.com/packages/2d/environments/free-platform-game-assets-85838


