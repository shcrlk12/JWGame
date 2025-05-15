using UnityEngine;

// 귀신 소울 에너지를 체크함.
// 소울 에너지가 작아질수록 보스가 약해져 처치하기 쉬움.
public class EnergyChecker
{
    public float MAX_SOUL_ENERGY = 100;
    public float SoulEnergy;
    public float RechargeSpeed = 5;

    public void Start()
    {
        //1. 소울 세팅
        SoulEnergy = MAX_SOUL_ENERGY;
    }

    public void RecoverySoulEnergy()
    {
        //소울 회복
        SoulEnergy += 5 * Time.deltaTime;
        SoulEnergy = Mathf.Max(SoulEnergy, MAX_SOUL_ENERGY);
    }

    public void ReduceSoulEnergy(float reduce)
    {
        //소울 감소
        SoulEnergy -= reduce;

        if (SoulEnergy <= 0)
        {
            //소울이 0이하 이면 게임 끝
            GameManager.Instance.Game.EndGame();
        }
    }
}
