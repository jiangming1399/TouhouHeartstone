﻿using System;
using System.Linq;
using TouhouCardEngine;
using System.Threading.Tasks;
using TouhouCardEngine.Interfaces;
namespace TouhouHeartstone.Builtin
{
    /// <summary>
    /// 鲁莽的妖精，111，冲锋
    /// </summary>
    public class RashFairy : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x001;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 1;
        public override int attack { get; set; } = 1;
        public override int life { get; set; } = 1;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override string[] keywords { get; set; } = new string[] { Keyword.CHARGE };
        public override IEffect[] effects { get; set; } = new IEffect[0];
    }
    /// <summary>
    /// 人类村落守卫，325，嘲讽
    /// </summary>
    public class HumanVillageGuard : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x002;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 3;
        public override int attack { get; set; } = 2;
        public override int life { get; set; } = 4;
        public override string[] keywords { get; set; } = new string[] { Keyword.TAUNT };
        public override IEffect[] effects { get; set; } = new IEffect[0];
    }
    /// <summary>
    /// 铁炮猎人 中立普通卡 322 战吼：造成2点伤害
    /// </summary>
    public class RifleHunter : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x003;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 3;
        public override int attack { get; set; } = 2;
        public override int life { get; set; } = 2;
        public override string[] keywords { get; set; } = new string[0];
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,vars)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                return true;
            },async (game,player,card,vars,targets)=>
            {
                Card target = targets[0] as Card;
                await target.damage(game,2);
            })
        };
    }
    /// <summary>
    /// 迷失亡灵 中立普通卡 541 亡语：召唤一个4/3的亡灵
    /// </summary>
    public class MissingSpecter : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x004;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 5;
        public override int attack { get; set; } = 4;
        public override int life { get; set; } = 1;
        public override string[] keywords { get; set; } = new string[0];
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffectAfter<THHCard.DeathEventArg>(PileName.GRAVE,(game,player,card,arg)=>
            {
                return arg.infoDic.Any(p=>p.Key==card);
            },(game,player,card,targets)=>
            {
                return true;
            },async (game,player,card,arg)=>
            {
                await arg.infoDic[card].player.createToken(game,game.getCardDefine<LostSpecter>(),arg.infoDic[card].position);
            })
        };
    }
    /// <summary>
    /// 失落亡灵 中立衍生物 543
    /// </summary>
    public class LostSpecter : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x005;
        public override int id { get; set; } = ID;
        public override bool isToken { get; set; } = true;
        public override int cost { get; set; } = 5;
        public override int attack { get; set; } = 4;
        public override int life { get; set; } = 3;
        public override string[] keywords { get; set; } = new string[0];
        public override IEffect[] effects { get; set; } = new IEffect[0];
    }
    public class DrizzleFairy : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x006;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 1;
        public override int attack { get; set; } = 1;
        public override int life { get; set; } = 2;
        public override int spellDamage { get; set; } = 1;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override string[] keywords { get; set; } = new string[0];
        public override IEffect[] effects { get; set; } = new IEffect[0];
    }
    public class LuckyCoin : SpellCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SPELL | 0x007;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 0;
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.HAND,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                return false;
            },async (game,player,card,arg,targets)=>
            {
                await arg.player.setGem(game,arg.player.gem + 1);
            })
        };
    }
    public class FlameFairy : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x008;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 1;
        public override int attack { get; set; } = 2;
        public override int life { get; set; } = 1;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                return false;
            },async (game,player,card,arg,targets)=>
            {
                THHPlayer opponent = game.getOpponent(arg.player);
                if(opponent.field.count>0)
                {
                    await opponent.field.randomTake(game,1).damage(game,1);
                }
            })
        };
    }
    public class SunnyMilk : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x009;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 2;
        public override int attack { get; set; } = 3;
        public override int life { get; set; } = 2;
        public override string[] keywords { get; set; } = new string[] { Keyword.STEALTH };
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[0];
    }
    public class LunaChild : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x010;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 2;
        public override int attack { get; set; } = 2;
        public override int life { get; set; } = 3;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                if(targets[0] is Card target && target.pile.name == PileName.FIELD)
                    return true;
                return false;
            },(game,player,card,arg,targets)=>
            {
                if(targets[0] is Card target)
                    target.setStealth(true);
                return Task.CompletedTask;
            })
        };
    }
    public class StarSphere : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x011;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 2;
        public override int attack { get; set; } = 1;
        public override int life { get; set; } = 4;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            //TODO:潜行光环
        };
    }
    public class BeerFairy : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x012;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 2;
        public override int attack { get; set; } = 3;
        public override int life { get; set; } = 2;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            //new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            //{
            //    return true;
            //},(game,player,card,targets)=>
            //{
            //    if(targets[0] is Card target && target.owner == player && target.pile.name == PileName.FIELD)
            //        return true;
            //    return false;
            //},async (game,player,card,arg,targets)=>
            //{
            //    THHPlayer opponent = game.getOpponent(arg.player);
            //    if(opponent.field.count>0)
            //    {
            //        await opponent.field.randomTake(game,1).damage(game,1);
            //    }
            //})
        };
    }
    public class SunflowerWarleader : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x013;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 3;
        public override int attack { get; set; } = 3;
        public override int life { get; set; } = 3;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            //new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            //{
            //    return true;
            //},(game,player,card,targets)=>
            //{
            //    if(targets[0] is Card target && target.owner == player && target.pile.name == PileName.FIELD)
            //        return true;
            //    return false;
            //},async (game,player,card,arg,targets)=>
            //{
            //    THHPlayer opponent = game.getOpponent(arg.player);
            //    if(opponent.field.count>0)
            //    {
            //        await opponent.field.randomTake(game,1).damage(game,1);
            //    }
            //})
        };
    }
    public class Cirno : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x014;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 3;
        public override int attack { get; set; } = 4;
        public override int life { get; set; } = 5;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                return false;
            },async (game,player,card,arg,targets)=>
            {
                foreach (var character in game.getAllCharacters().randomTake(game,3))
                {
                    //character.setFreeze(true);
                }
            })
        };
    }
    public class Daiyousei : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x015;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 3;
        public override int attack { get; set; } = 4;
        public override int life { get; set; } = 2;
        public override string[] keywords { get; set; } = new string[] { Keyword.CHARGE };
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffectAfter<THHCard.DeathEventArg>(PileName.GRAVE,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                return false;
            },async (game,player,card,arg)=>
            {
                THHPlayer opponent = game.getOpponent(card.owner as THHPlayer);
                await opponent.setMaxGem(game, opponent.maxGem + 1);
                await opponent.setGem(game, opponent.gem + 1);
            })
        };
    }
    public class Cirno_IceFall : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x016;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 4;
        public override int attack { get; set; } = 4;
        public override int life { get; set; } = 5;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                if(targets[0] is Card target && target.pile.name == PileName.FIELD)
                    return true;
                return false;
            },async (game,player,card,arg,targets)=>
            {
                if(targets[0] is Card target)
                {
                    //target.getNearbyCards().setFreeze(true);
                }
            })
        };
    }
    public class Clownpiece : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x017;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 5;
        public override int attack { get; set; } = 4;
        public override int life { get; set; } = 4;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                return false;
            },async (game,player,card,arg,targets)=>
            {
                foreach (var servant in game.getAllServants())
                {
                    servant.addBuff(game, new ClownpieceBuff());
                }
            })
        };
    }
    public class ClownpieceBuff : Buff
    {
        public const int ID = Clownpiece.ID;
        public override int id { get; } = ID;
        public override PropModifier[] modifiers { get; } = new PropModifier[]
        {
            new AttackModifier(2)
        };
    }
    public class ForestFairy : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x018;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 8;
        public override int attack { get; set; } = 8;
        public override int life { get; set; } = 8;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            //new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            //{
            //    return true;
            //},(game,player,card,targets)=>
            //{
            //    return false;
            //},async (game,player,card,arg,targets)=>
            //{
            //    foreach (var servant in game.getAllServants())
            //    {
            //        servant.addBuff(game, new ClownpieceBuff());
            //    }
            //})
        };
    }
    public class EternityLarva : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x019;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 1;
        public override int attack { get; set; } = 1;
        public override int life { get; set; } = 2;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                if(targets[0] is Card target && target.pile.name == PileName.FIELD)
                    return true;
                return false;
            },async (game,player,card,arg,targets)=>
            {
                if(targets[0] is Card target)
                {
                    //target.setPoision(true);
                }
            })
        };
    }
    public class LilyWhite : ServantCardDefine
    {
        public const int ID = CardCategory.CHARACTER_NEUTRAL | CardCategory.SERVANT | 0x020;
        public override int id { get; set; } = ID;
        public override int cost { get; set; } = 4;
        public override int attack { get; set; } = 2;
        public override int life { get; set; } = 3;
        public override string[] tags { get; set; } = new string[] { CardTag.FAIRY };
        public override IEffect[] effects { get; set; } = new IEffect[]
        {
            new THHEffect<THHPlayer.ActiveEventArg>(PileName.FIELD,(game,player,card,arg)=>
            {
                return true;
            },(game,player,card,targets)=>
            {
                return false;
            },async (game,player,card,arg,targets)=>
            {
                await game.players.Select(p=>p.master).heal(game,4);
                foreach (var p in game.players)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        await p.draw(game);
                    }
                }
            })
        };
    }
}