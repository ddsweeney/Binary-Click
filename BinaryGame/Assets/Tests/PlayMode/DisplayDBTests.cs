using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class DisplayDBTests
{
    private TMP_Text nametxt1;
    private TMP_Text nametxt2;
    private TMP_Text nametxt3;
    private TMP_Text nametxt4;
    private TMP_Text nametxt5;
    private TMP_Text scoretxt1;
    private TMP_Text scoretxt2;
    private TMP_Text scoretxt3;
    private TMP_Text scoretxt4;
    private TMP_Text scoretxt5;

    private TMP_Text extraname;
    private TMP_Text extrascore;

    private DisplayDbController displayDb;
    // A Test behaves as an ordinary method
    [SetUp]
    public void SetUp()
    {
        var controller = new GameObject();
        var name1 = new GameObject();
        var name2 = new GameObject();
        var name3 = new GameObject();
        var name4 = new GameObject();
        var name5 = new GameObject();
        var extran = new GameObject();
        var extras = new GameObject();
        var score1 = new GameObject();
        var score2 = new GameObject();
        var score3 = new GameObject();
        var score4 = new GameObject();
        var score5 = new GameObject();

        displayDb = controller.AddComponent<DisplayDbController>();
        nametxt1 = name1.AddComponent<TextMeshProUGUI>();
        nametxt2 = name2.AddComponent<TextMeshProUGUI>();
        nametxt3 = name3.AddComponent<TextMeshProUGUI>();
        nametxt4 = name4.AddComponent<TextMeshProUGUI>();
        nametxt5 = name5.AddComponent<TextMeshProUGUI>();
        extraname = extran.AddComponent<TextMeshProUGUI>();
        extrascore = extras.AddComponent<TextMeshProUGUI>();
        scoretxt1 = score1.AddComponent<TextMeshProUGUI>();
        scoretxt2 = score2.AddComponent<TextMeshProUGUI>();
        scoretxt3 = score3.AddComponent<TextMeshProUGUI>();
        scoretxt4 = score4.AddComponent<TextMeshProUGUI>();
        scoretxt5 = score5.AddComponent<TextMeshProUGUI>();

        displayDb.extraname = extraname;
        displayDb.extrascore = extrascore;

        displayDb.nametxt1 = nametxt1;
        displayDb.nametxt2 = nametxt2;
        displayDb.nametxt3 = nametxt3;
        displayDb.nametxt4 = nametxt4;
        displayDb.nametxt5 = nametxt5;

        displayDb.scoretxt1 = scoretxt1;
        displayDb.scoretxt2 = scoretxt2;
        displayDb.scoretxt3 = scoretxt3;
        displayDb.scoretxt4 = scoretxt4;
        displayDb.scoretxt5 = scoretxt5;

    }


    [UnityTest]
    public IEnumerator DisplayBintodec()
    {

        displayDb.DisplayBintodecDB();

        Assert.NotNull(displayDb.extraname);
        Assert.NotNull(displayDb.extrascore);
        Assert.NotNull(displayDb.nametxt1);
        Assert.NotNull(displayDb.scoretxt1);
        Assert.NotNull(displayDb.nametxt2);
        Assert.NotNull(displayDb.scoretxt2);
        Assert.NotNull(displayDb.nametxt3);
        Assert.NotNull(displayDb.scoretxt3);
        Assert.NotNull(displayDb.nametxt4);
        Assert.NotNull(displayDb.scoretxt4);
        Assert.NotNull(displayDb.nametxt5);
        Assert.NotNull(displayDb.scoretxt5);

        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator DisplayDectobin()
    {

        displayDb.DisplayBintodecDB();

        Assert.NotNull(displayDb.extraname);
        Assert.NotNull(displayDb.extrascore);
        Assert.NotNull(displayDb.nametxt1);
        Assert.NotNull(displayDb.scoretxt1);
        Assert.NotNull(displayDb.nametxt2);
        Assert.NotNull(displayDb.scoretxt2);
        Assert.NotNull(displayDb.nametxt3);
        Assert.NotNull(displayDb.scoretxt3);
        Assert.NotNull(displayDb.nametxt4);
        Assert.NotNull(displayDb.scoretxt4);
        Assert.NotNull(displayDb.nametxt5);
        Assert.NotNull(displayDb.scoretxt5);

        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator DisplayBintohex()
    {

        displayDb.DisplayBintodecDB();

        Assert.NotNull(displayDb.extraname);
        Assert.NotNull(displayDb.extrascore);
        Assert.NotNull(displayDb.nametxt1);
        Assert.NotNull(displayDb.scoretxt1);
        Assert.NotNull(displayDb.nametxt2);
        Assert.NotNull(displayDb.scoretxt2);
        Assert.NotNull(displayDb.nametxt3);
        Assert.NotNull(displayDb.scoretxt3);
        Assert.NotNull(displayDb.nametxt4);
        Assert.NotNull(displayDb.scoretxt4);
        Assert.NotNull(displayDb.nametxt5);
        Assert.NotNull(displayDb.scoretxt5);

        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator DisplayHextobin()
    {

        displayDb.DisplayBintodecDB();

        Assert.NotNull(displayDb.extraname);
        Assert.NotNull(displayDb.extrascore);
        Assert.NotNull(displayDb.nametxt1);
        Assert.NotNull(displayDb.scoretxt1);
        Assert.NotNull(displayDb.nametxt2);
        Assert.NotNull(displayDb.scoretxt2);
        Assert.NotNull(displayDb.nametxt3);
        Assert.NotNull(displayDb.scoretxt3);
        Assert.NotNull(displayDb.nametxt4);
        Assert.NotNull(displayDb.scoretxt4);
        Assert.NotNull(displayDb.nametxt5);
        Assert.NotNull(displayDb.scoretxt5);

        yield return new WaitForSeconds(0.1f);
    }

    [UnityTest]
    public IEnumerator DisplayDectohex()
    {

        displayDb.DisplayBintodecDB();

        Assert.NotNull(displayDb.extraname);
        Assert.NotNull(displayDb.extrascore);
        Assert.NotNull(displayDb.nametxt1);
        Assert.NotNull(displayDb.scoretxt1);
        Assert.NotNull(displayDb.nametxt2);
        Assert.NotNull(displayDb.scoretxt2);
        Assert.NotNull(displayDb.nametxt3);
        Assert.NotNull(displayDb.scoretxt3);
        Assert.NotNull(displayDb.nametxt4);
        Assert.NotNull(displayDb.scoretxt4);
        Assert.NotNull(displayDb.nametxt5);
        Assert.NotNull(displayDb.scoretxt5);

        yield return new WaitForSeconds(0.1f);
    }
    [UnityTest]
    public IEnumerator DisplayHextodec()
    {

        displayDb.DisplayBintodecDB();

        Assert.NotNull(displayDb.extraname);
        Assert.NotNull(displayDb.extrascore);
        Assert.NotNull(displayDb.nametxt1);
        Assert.NotNull(displayDb.scoretxt1);
        Assert.NotNull(displayDb.nametxt2);
        Assert.NotNull(displayDb.scoretxt2);
        Assert.NotNull(displayDb.nametxt3);
        Assert.NotNull(displayDb.scoretxt3);
        Assert.NotNull(displayDb.nametxt4);
        Assert.NotNull(displayDb.scoretxt4);
        Assert.NotNull(displayDb.nametxt5);
        Assert.NotNull(displayDb.scoretxt5);

        yield return new WaitForSeconds(0.1f);
    }
}
