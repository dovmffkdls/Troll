using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ChaObjManager : MonoSingleton<ChaObjManager>
{
    [SerializeField] RectTransform chaParant;

    public Player player;
    [SerializeField] List<Animator> playerAnimObjList = new List<Animator>();

    private List<EnumyAI> enumyAnimList = new List<EnumyAI>();
    [SerializeField] List<Animator> enumyAnimObjList = new List<Animator>();

    public void ChangePlayerCha(PCData pcData)
    {
        Animator currentAnim = null;

        foreach (var playerAnimObj in playerAnimObjList)
        {
            string pcid = playerAnimObj.name.Split('_')[0];

            if (pcid == pcData.PcGId.ToString())
            {
                currentAnim = playerAnimObj;
            }
        }

        if (currentAnim != null)
        {
            if (this.player != null)
            {
                Destroy(this.player.gameObject);
            }

            Animator newAnimator = Instantiate(currentAnim, chaParant);
            newAnimator.transform.localPosition = new Vector3(-100, 0, 0);
            newAnimator.transform.localScale = new Vector3(-1, 1, 1);

            Player player = newAnimator.gameObject.AddComponent<Player>();
            player.Init(pcData);

            this.player = player;
        }
    }

    public void CreateEnumy(MobAData aniData , MobBData mobBData , UnityAction<EnumyAI> dieEvent = null)
    {
        Animator currentAnim = null;

        foreach (var enumyAnimObj in enumyAnimObjList)
        {
            string pcid = enumyAnimObj.name.Split('_')[0];

            if (pcid == aniData.MobGId.ToString())
            {
                currentAnim = enumyAnimObj;
            }
        }

        if (currentAnim != null)
        {
            Animator newAnimator = Instantiate(currentAnim, chaParant);

            float yValue = Random.Range(-5, 5);

            newAnimator.transform.localPosition = new Vector3(110, yValue, 0);
            newAnimator.transform.localScale = new Vector3(1, 1, 1);
            newAnimator.Play("01_walk");

            EnumyAI enumyAI = newAnimator.gameObject.AddComponent<EnumyAI>();
            enumyAI.Init(mobBData);
            enumyAI.dieEventOn = dieEvent;
            enumyAnimList.Add(enumyAI);
        }
    }

    public void RemoveEnumy(EnumyAI anim)
    {
        enumyAnimList.Remove(anim);
        Destroy(anim.gameObject);
    }

    public List<EnumyAI> GetEnumyList()
    {
        return enumyAnimList.Where(data => data.enumyStatus != EnumyStatus.Die).ToList();
    }

    public Player GetPlayer()
    {
        return player;
    }
}
