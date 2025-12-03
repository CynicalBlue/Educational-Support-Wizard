// Decompiled with JetBrains decompiler
// Type: Main
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7126F414-EEBF-4ED7-A2DC-424CB65E894B
// Assembly location: C:\Users\weird\Downloads\9-9-2025_Educational_Support_Wizard\Educational_Support_Wizard_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

#nullable disable
public class Main : MonoBehaviour
{
    public int numberOfDecisions;
    public bool onBPath;
    public bool fourPathActive;
    public string currentPathName = "placeholder";
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject thirdButton;
    public GameObject fourthButton;
    public GameObject continueButton;
    public TMP_Text yesButtonText;
    public TMP_Text noButtonText;
    public TMP_Text thirdButtonText;
    public TMP_Text fourthButtonText;
    public GameObject placeHolderBackground;
    public GameObject twoPathImage;
    public GameObject threePathImage;
    public GameObject LTDZoneImage;
    public GameObject CTLIZoneImage;
    public GameObject EdTechZoneImage;
    public GameObject MSUITZoneImage;
    public GameObject twoPathSign;
    public GameObject threePathSign;
    public GameObject d2LCourseBuildHouse;
    public GameObject multimediaHouse;
    public GameObject redevelopCourseHouse;
    public GameObject accessibilityHouse;
    public GameObject twoPathSignFirst;
    public GameObject twoPathSignSecond;
    public GameObject threePathSignFirst;
    public GameObject threePathSignSecond;
    public GameObject threePathSignThird;
    public GameObject guySprite;
    public GameObject guyHappySprite;
    public GameObject guyCastingSprite;
    public GameObject guyHoldingStaffSprite;
    public GameObject textBubble;
    public TMP_Text textBubbleText;
    public int matthiasTextAmount;
    public Coroutine typingCoroutine;
    public float typingSpeed = 0.1f;
    public bool isTyping;
    public TMP_Text typingTextBubbleText;
    public GameObject bigTownBackground;
    public GameObject bigTownLeftMostSign;
    public GameObject bigTownRightMostSign;
    public GameObject bigTownLeftMiddleSign;
    public GameObject bigTownRightMiddleSign;
    public GameObject bigTownLeftMostSignHover;
    public GameObject bigTownRightMostSignHover;
    public GameObject bigTownLeftMiddleSignHover;
    public GameObject bigTownRightMiddleSignHover;
    public GameObject scrollClosed;
    public GameObject scrollOpened;
    public GameObject linkText;
    public TMP_Text linkTextText;
    public GameObject clickHereText;
    public GameObject startButton;
    public GameObject creditsButton;
    public GameObject exitButton;
    public GameObject backButton;
    public GameObject creditsText;
    public GameObject startButtonHover;
    public GameObject creditsButtonHover;
    public GameObject exitButtonHover;
    public GameObject backButtonHover;
    public string previousPath;
    public GameObject prevButton;
    public GameObject prevButtonHover;
    public int prevChoiceID;
    public int prevChoiceIDHolder;
    public List<int> prevPathList = new List<int>();
    public bool wentBack;
    public VideoClip transitionIntoTown;
    public GameObject mainCameraReference;
    public VideoPlayer mainCameraVideoPlayer;
    public bool didVideoPlay;
    public string prevPathForVideo = "";
    public string currentEmailPath = "FailSafePlaceholder@example.com";
    public bool cutsceneBlocker;
    public AudioSource forestMusic;
    public AudioSource LTDMusic;
    public AudioSource CTLIMusic;
    public AudioSource ITAndEdTechMusic;
    public AudioSource scrollOpenSound;
    public GameObject yesSkipButton;
    public GameObject yesSkipButtonHover;
    public GameObject noSkipButton;
    public GameObject noSkipButtonHover;
    public GameObject textBoxYesNo;
    public AudioSource ttsClip1;
    public AudioSource ttsClip2;
    public AudioSource ttsClip3;
    public AudioSource ttsClip4;
    public AudioSource ttsClip5;
    public AudioSource ttsClip6;
    public AudioSource ttsClip7;
    public AudioSource ttsClipA1;
    public AudioSource ttsClipA2;
    public AudioSource ttsClipA3;
    public AudioSource ttsClipRedev1;
    public AudioSource ttsClipRedev2;
    public AudioSource ttsClipD2LB1;
    public AudioSource ttsClipD2LB2;
    public AudioSource ttsClipMultimedia1;
    public AudioSource ttsClipQM1;
    public AudioSource ttsClipB1;
    public AudioSource ttsClipB2;
    public AudioSource ttsClipATool1;
    public AudioSource ttsClipHelp1;
    public AudioSource ttsClipHelp2;
    public AudioSource ttsClipHelp3;
    public AudioSource ttsClipAssistance1;
    public AudioSource ttsClipAssistance2;
    public AudioSource ttsClipAssistance3;
    public AudioSource ttsClipBMSUIT1;
    public AudioSource ttsClipBMSUIT2;
    public AudioSource ttsClipCMSUIT1;
    public AudioSource ttsClipCPathStart1;
    public AudioSource ttsClipABTraining1;
    public AudioSource ttsClipOneOnOne1;
    public AudioSource ttsClipWorkshop1;
    public AudioSource ttsClipWorkshop2;
    public AudioSource ttsClipFeedback1;
    public bool firstTTSClipPlayed;

    private void Awake()
    {
        this.linkTextText = this.linkText.GetComponent<TMP_Text>();
        this.yesButtonText = this.yesButton.GetComponentInChildren<TMP_Text>();
        this.noButtonText = this.noButton.GetComponentInChildren<TMP_Text>();
        this.thirdButtonText = this.thirdButton.GetComponentInChildren<TMP_Text>();
        this.fourthButtonText = this.fourthButton.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf) && this.isTyping)
        {
            this.SkipTyping();
        }
        else
        {
            if (!Input.GetMouseButtonDown(0) || !this.guySprite.activeSelf && !this.guyHappySprite.activeSelf && !this.guyCastingSprite.activeSelf && !this.guyHoldingStaffSprite.activeSelf || this.isTyping)
                return;
            this.UpdateMatthiasText();
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        this.mainCameraVideoPlayer.loopPointReached -= new VideoPlayer.EventHandler(this.OnVideoFinished);
        this.mainCameraVideoPlayer.Stop();
        Cursor.lockState = CursorLockMode.None;
        this.didVideoPlay = true;
        if (this.prevPathForVideo == "yes")
            this.Yes();
        if (this.prevPathForVideo == "no")
            this.No();
        if (this.prevPathForVideo == "third")
            this.Third();
        if (!(this.prevPathForVideo == "fourth"))
            return;
        this.Fourth();
    }

    public void Yes()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf)
            return;
        if (this.numberOfDecisions == 0 && !this.onBPath)
        {
            if (!this.didVideoPlay && !this.cutsceneBlocker)
            {
                Cursor.lockState = CursorLockMode.Locked;
                this.mainCameraReference = GameObject.Find("Main Camera");
                this.mainCameraVideoPlayer = this.mainCameraReference.GetComponent<VideoPlayer>();
                this.mainCameraVideoPlayer.loopPointReached += new VideoPlayer.EventHandler(this.OnVideoFinished);
                this.prevPathForVideo = "yes";
                this.mainCameraVideoPlayer.Play();
                this.cutsceneBlocker = true;
            }
            else
            {
                this.didVideoPlay = false;
                this.yesButton.SetActive(false);
                this.noButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.fourthButton.SetActive(false);
                this.typingTextBubbleText.text = "";
                this.guySprite.SetActive(false);
                this.guyHappySprite.SetActive(false);
                this.guyCastingSprite.SetActive(false);
                this.guyHoldingStaffSprite.SetActive(true);
                this.textBubble.SetActive(true);
                this.StopCurrentAudioClips();
                this.textBubbleText.text = "Looks like you want to contact someone from the Learning Technology and Development team.";
                this.ttsClipA1.Play();
                this.matthiasTextAmount = 7;
                this.yesButton.transform.localPosition = new Vector3(-727f, -246f, 0.0f);
                this.noButton.transform.localPosition = new Vector3(500f, -390f, 0.0f);
                this.thirdButton.transform.localPosition = new Vector3(56f, -164f, 0.0f);
                this.fourthButton.transform.localPosition = new Vector3(805f, -380f, 0.0f);
                this.noButtonText.fontSize = 11f;
                this.yesButtonText.fontSize = 11f;
                this.thirdButtonText.margin = new Vector4(47f, 0.0f, 50f, 0.0f);
                this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                this.twoPathSign.SetActive(false);
                this.threePathSign.SetActive(false);
                ++this.numberOfDecisions;
                this.fourPathActive = true;
                this.yesButtonText.text = "Redeveloping your course";
                this.noButtonText.text = "D2L course building";
                this.thirdButtonText.text = "Audio/Video Creation";
                this.fourthButtonText.text = "Course Quality Review";
                this.twoPathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.placeHolderBackground.SetActive(false);
                this.twoPathSignFirst.SetActive(false);
                this.twoPathSignSecond.SetActive(false);
                this.threePathSignFirst.SetActive(false);
                this.threePathSignSecond.SetActive(false);
                this.threePathSignThird.SetActive(false);
                this.bigTownBackground.SetActive(true);
                this.previousPath = "A";
                if (!this.LTDMusic.isPlaying)
                {
                    this.forestMusic.Stop();
                    this.LTDMusic.Play();
                }
                if (!this.wentBack)
                {
                    this.prevChoiceIDHolder = this.prevChoiceID;
                    this.prevPathList.Add(this.prevChoiceIDHolder);
                }
                else
                    this.wentBack = false;
                this.prevChoiceID = 1;
                this.StartCoroutine((IEnumerator)this.TypeText());
            }
        }
        else if (this.numberOfDecisions == 1 && this.onBPath && !this.fourPathActive)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(true);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Are you still in need of deciding an appropriate tool?";
            this.ttsClipATool1.Play();
            this.matthiasTextAmount = 35;
            this.yesButton.transform.localPosition = new Vector3(0.0f, 240f, 0.0f);
            this.noButton.transform.localPosition = new Vector3(825f, -120f, 0.0f);
            this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            this.twoPathSign.SetActive(false);
            this.threePathSign.SetActive(false);
            ++this.numberOfDecisions;
            this.yesButtonText.text = "Yes, I need help selecting.";
            this.noButtonText.text = "No, I need use assistance.";
            this.yesButton.SetActive(false);
            this.noButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.twoPathImage.SetActive(true);
            this.threePathImage.SetActive(false);
            this.placeHolderBackground.SetActive(false);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
            this.twoPathSign.SetActive(true);
            this.yesButton.SetActive(true);
            this.noButton.SetActive(true);
            this.previousPath = "A";
            if (!this.wentBack)
            {
                this.prevChoiceIDHolder = this.prevChoiceID;
                this.prevPathList.Add(this.prevChoiceIDHolder);
            }
            else
                this.wentBack = false;
            this.prevChoiceID = 2;
            this.StartCoroutine((IEnumerator)this.TypeText());
        }
        else if (this.numberOfDecisions == 1 && !this.onBPath && !this.fourPathActive)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(true);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Were you looking for a workshop style training or a one-on-one consultation?";
            this.ttsClipABTraining1.Play();
            this.matthiasTextAmount = 35;
            this.yesButton.transform.localPosition = new Vector3(0.0f, 240f, 0.0f);
            this.noButton.transform.localPosition = new Vector3(825f, -120f, 0.0f);
            this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            this.twoPathSign.SetActive(false);
            this.threePathSign.SetActive(false);
            ++this.numberOfDecisions;
            this.yesButtonText.text = "One-on-one";
            this.noButtonText.text = "Workshop";
            this.yesButton.SetActive(false);
            this.noButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.fourthButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.twoPathImage.SetActive(true);
            this.threePathImage.SetActive(false);
            this.placeHolderBackground.SetActive(false);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
            this.twoPathSign.SetActive(true);
            this.yesButton.SetActive(true);
            this.noButton.SetActive(true);
            this.previousPath = "A";
            if (!this.wentBack)
            {
                this.prevChoiceIDHolder = this.prevChoiceID;
                this.prevPathList.Add(this.prevChoiceIDHolder);
            }
            else
                this.wentBack = false;
            this.prevChoiceID = 3;
            this.StartCoroutine((IEnumerator)this.TypeText());
        }
        else if (this.numberOfDecisions == 2 && !this.fourPathActive && this.onBPath)
        {
            if (!this.didVideoPlay && !this.cutsceneBlocker)
            {
                Cursor.lockState = CursorLockMode.Locked;
                this.mainCameraReference = GameObject.Find("Main Camera");
                this.mainCameraVideoPlayer = this.mainCameraReference.GetComponent<VideoPlayer>();
                this.mainCameraVideoPlayer.loopPointReached += new VideoPlayer.EventHandler(this.OnVideoFinished);
                this.prevPathForVideo = "yes";
                this.mainCameraVideoPlayer.Play();
                this.cutsceneBlocker = true;
            }
            else
            {
                this.didVideoPlay = false;
                this.typingTextBubbleText.text = "";
                this.guySprite.SetActive(false);
                this.guyHappySprite.SetActive(false);
                this.guyCastingSprite.SetActive(false);
                this.guyHoldingStaffSprite.SetActive(true);
                this.textBubble.SetActive(true);
                this.StopCurrentAudioClips();
                this.textBubbleText.text = "Need help selecting an appropriate tool for your course?";
                this.ttsClipHelp1.Play();
                this.matthiasTextAmount = 14;
                this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                this.twoPathSign.SetActive(false);
                this.threePathSign.SetActive(false);
                ++this.numberOfDecisions;
                this.yesButton.SetActive(false);
                this.noButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.fourthButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.twoPathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.placeHolderBackground.SetActive(false);
                this.LTDZoneImage.SetActive(true);
                this.twoPathSignFirst.SetActive(false);
                this.twoPathSignSecond.SetActive(false);
                this.threePathSignFirst.SetActive(false);
                this.threePathSignSecond.SetActive(false);
                this.threePathSignThird.SetActive(false);
                this.linkTextText.text = "https://broad.msu.edu/lxd/";
                this.previousPath = "A";
                this.forestMusic.Stop();
                this.LTDMusic.Play();
                if (!this.wentBack)
                {
                    this.prevChoiceIDHolder = this.prevChoiceID;
                    this.prevPathList.Add(this.prevChoiceIDHolder);
                }
                else
                    this.wentBack = false;
                this.prevChoiceID = 4;
                this.StartCoroutine((IEnumerator)this.TypeText());
            }
        }
        else if (this.numberOfDecisions == 2 && !this.fourPathActive && !this.onBPath)
        {
            if (!this.didVideoPlay && !this.cutsceneBlocker)
            {
                Cursor.lockState = CursorLockMode.Locked;
                this.mainCameraReference = GameObject.Find("Main Camera");
                this.mainCameraVideoPlayer = this.mainCameraReference.GetComponent<VideoPlayer>();
                this.mainCameraVideoPlayer.loopPointReached += new VideoPlayer.EventHandler(this.OnVideoFinished);
                this.prevPathForVideo = "yes";
                this.mainCameraVideoPlayer.Play();
                this.cutsceneBlocker = true;
            }
            else
            {
                this.didVideoPlay = false;
                this.typingTextBubbleText.text = "";
                this.guySprite.SetActive(false);
                this.guyHappySprite.SetActive(true);
                this.guyCastingSprite.SetActive(false);
                this.guyHoldingStaffSprite.SetActive(false);
                this.textBubble.SetActive(true);
                this.StopCurrentAudioClips();
                this.textBubbleText.text = "Looking for a one-on-one style consultation?";
                this.ttsClipOneOnOne1.Play();
                this.matthiasTextAmount = 26;
                this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                this.twoPathSign.SetActive(false);
                this.threePathSign.SetActive(false);
                ++this.numberOfDecisions;
                this.yesButton.SetActive(false);
                this.noButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.fourthButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.twoPathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.placeHolderBackground.SetActive(false);
                this.LTDZoneImage.SetActive(true);
                this.twoPathSignFirst.SetActive(false);
                this.twoPathSignSecond.SetActive(false);
                this.threePathSignFirst.SetActive(false);
                this.threePathSignSecond.SetActive(false);
                this.threePathSignThird.SetActive(false);
                this.linkTextText.text = "https://broad.msu.edu/lxd/";
                this.previousPath = "A";
                this.forestMusic.Stop();
                this.LTDMusic.Play();
                if (!this.wentBack)
                {
                    this.prevChoiceIDHolder = this.prevChoiceID;
                    this.prevPathList.Add(this.prevChoiceIDHolder);
                }
                else
                    this.wentBack = false;
                this.prevChoiceID = 5;
                this.StartCoroutine((IEnumerator)this.TypeText());
            }
        }
        else
        {
            if (!this.fourPathActive)
                return;
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(true);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Looks like you will need to contact LTD’s Learning Experience Manager about your questions!";
            this.ttsClipRedev1.Play();
            this.matthiasTextAmount = 10;
            this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            this.currentEmailPath = "benne784@broad.msu.edu";
            this.twoPathSign.SetActive(false);
            this.threePathSign.SetActive(false);
            this.yesButton.SetActive(false);
            this.noButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.fourthButton.SetActive(false);
            this.twoPathImage.SetActive(false);
            this.threePathImage.SetActive(false);
            this.placeHolderBackground.SetActive(false);
            this.d2LCourseBuildHouse.SetActive(false);
            this.accessibilityHouse.SetActive(false);
            this.multimediaHouse.SetActive(true);
            this.redevelopCourseHouse.SetActive(false);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
            this.bigTownBackground.SetActive(false);
            this.bigTownLeftMostSign.SetActive(false);
            this.bigTownLeftMiddleSign.SetActive(false);
            this.bigTownRightMiddleSign.SetActive(false);
            this.bigTownRightMostSign.SetActive(false);
            this.bigTownLeftMostSignHover.SetActive(false);
            this.bigTownLeftMiddleSignHover.SetActive(false);
            this.bigTownRightMiddleSignHover.SetActive(false);
            this.bigTownRightMostSignHover.SetActive(false);
            ++this.numberOfDecisions;
            this.previousPath = "A";
            if (!this.wentBack)
            {
                this.prevChoiceIDHolder = this.prevChoiceID;
                this.prevPathList.Add(this.prevChoiceIDHolder);
            }
            else
                this.wentBack = false;
            this.prevChoiceID = 6;
            this.StartCoroutine((IEnumerator)this.TypeText());
        }
    }

    public void No()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf)
            return;
        if (this.numberOfDecisions == 0 && !this.fourPathActive)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(true);
            this.textBubble.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Ahh technology, there’s quite a few talents who can help with that.";
            this.ttsClipB1.Play();
            this.matthiasTextAmount = 12;
            this.yesButton.transform.localPosition = new Vector3(-10f, 200f, 0.0f);
            this.noButton.transform.localPosition = new Vector3(615f, -180f, 0.0f);
            this.thirdButton.transform.localPosition = new Vector3(-265f, -30f, 0.0f);
            this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -16f);
            this.twoPathSign.SetActive(false);
            this.threePathSign.SetActive(false);
            this.yesButton.SetActive(false);
            this.noButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.yesButtonText.text = "A: Is your question about how to select and us the appropriate technology?";
            this.noButtonText.text = "B: Is your question related to solving classroom tech installation?";
            this.thirdButtonText.text = "C: Is your question related to solving a general tech issue?";
            ++this.numberOfDecisions;
            this.onBPath = true;
            this.twoPathImage.SetActive(false);
            this.threePathImage.SetActive(true);
            this.placeHolderBackground.SetActive(false);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
            this.previousPath = "B";
            if (!this.wentBack)
            {
                this.prevChoiceIDHolder = this.prevChoiceID;
                this.prevPathList.Add(this.prevChoiceIDHolder);
            }
            else
                this.wentBack = false;
            this.prevChoiceID = 7;
            this.StartCoroutine((IEnumerator)this.TypeText());
        }
        else if (this.numberOfDecisions == 1 && this.onBPath && !this.fourPathActive)
        {
            if (!this.didVideoPlay && !this.cutsceneBlocker)
            {
                Cursor.lockState = CursorLockMode.Locked;
                this.mainCameraReference = GameObject.Find("Main Camera");
                this.mainCameraVideoPlayer = this.mainCameraReference.GetComponent<VideoPlayer>();
                this.mainCameraVideoPlayer.loopPointReached += new VideoPlayer.EventHandler(this.OnVideoFinished);
                this.prevPathForVideo = "no";
                this.mainCameraVideoPlayer.Play();
                this.cutsceneBlocker = true;
            }
            else
            {
                this.didVideoPlay = false;
                this.typingTextBubbleText.text = "";
                this.guySprite.SetActive(true);
                this.guyHappySprite.SetActive(false);
                this.guyCastingSprite.SetActive(false);
                this.guyHoldingStaffSprite.SetActive(false);
                this.textBubble.SetActive(true);
                this.StopCurrentAudioClips();
                this.textBubbleText.text = "You will need to contact the MSU IT Team about your inquiry.";
                this.ttsClipBMSUIT1.Play();
                this.matthiasTextAmount = 20;
                this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                this.twoPathSign.SetActive(false);
                this.threePathSign.SetActive(false);
                this.yesButton.SetActive(false);
                this.noButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.fourthButton.SetActive(false);
                ++this.numberOfDecisions;
                this.twoPathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.placeHolderBackground.SetActive(false);
                this.MSUITZoneImage.SetActive(true);
                this.twoPathSignFirst.SetActive(false);
                this.twoPathSignSecond.SetActive(false);
                this.threePathSignFirst.SetActive(false);
                this.threePathSignSecond.SetActive(false);
                this.threePathSignThird.SetActive(false);
                this.linkTextText.text = "https://tech.msu.edu/help-and-support/";
                this.previousPath = "B";
                this.forestMusic.Stop();
                this.ITAndEdTechMusic.Play();
                if (!this.wentBack)
                {
                    this.prevChoiceIDHolder = this.prevChoiceID;
                    this.prevPathList.Add(this.prevChoiceIDHolder);
                }
                else
                    this.wentBack = false;
                this.prevChoiceID = 8;
                this.StartCoroutine((IEnumerator)this.TypeText());
            }
        }
        else if (this.numberOfDecisions == 1 && !this.onBPath && !this.fourPathActive)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(true);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Were you looking for a workshop style training or a one-on-one consultation?";
            this.ttsClipABTraining1.Play();
            this.matthiasTextAmount = 35;
            this.yesButton.transform.localPosition = new Vector3(0.0f, 240f, 0.0f);
            this.noButton.transform.localPosition = new Vector3(825f, -120f, 0.0f);
            this.twoPathSign.SetActive(true);
            this.threePathSign.SetActive(false);
            this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            ++this.numberOfDecisions;
            this.yesButtonText.text = "One-on-one";
            this.noButtonText.text = "Workshop";
            this.yesButton.SetActive(true);
            this.noButton.SetActive(true);
            this.thirdButton.SetActive(false);
            this.fourthButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.twoPathImage.SetActive(true);
            this.threePathImage.SetActive(false);
            this.placeHolderBackground.SetActive(false);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
            this.twoPathSign.SetActive(true);
            this.yesButton.SetActive(true);
            this.noButton.SetActive(true);
            this.previousPath = "B";
            if (!this.wentBack)
            {
                this.prevChoiceIDHolder = this.prevChoiceID;
                this.prevPathList.Add(this.prevChoiceIDHolder);
            }
            else
                this.wentBack = false;
            this.prevChoiceID = 9;
            this.StartCoroutine((IEnumerator)this.TypeText());
        }
        else if (this.numberOfDecisions == 2 && !this.fourPathActive && this.onBPath)
        {
            if (!this.didVideoPlay && !this.cutsceneBlocker)
            {
                Cursor.lockState = CursorLockMode.Locked;
                this.mainCameraReference = GameObject.Find("Main Camera");
                this.mainCameraVideoPlayer = this.mainCameraReference.GetComponent<VideoPlayer>();
                this.mainCameraVideoPlayer.loopPointReached += new VideoPlayer.EventHandler(this.OnVideoFinished);
                this.prevPathForVideo = "no";
                this.mainCameraVideoPlayer.Play();
                this.cutsceneBlocker = true;
            }
            else
            {
                this.typingTextBubbleText.text = "";
                this.guySprite.SetActive(false);
                this.guyHappySprite.SetActive(true);
                this.guyCastingSprite.SetActive(false);
                this.guyHoldingStaffSprite.SetActive(false);
                this.textBubble.SetActive(true);
                this.StopCurrentAudioClips();
                this.textBubbleText.text = "Need use assistance with your teaching tool?";
                this.ttsClipAssistance1.Play();
                this.matthiasTextAmount = 17;
                this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                this.twoPathSign.SetActive(false);
                this.threePathSign.SetActive(false);
                ++this.numberOfDecisions;
                this.yesButton.SetActive(false);
                this.noButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.fourthButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.twoPathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.placeHolderBackground.SetActive(false);
                this.EdTechZoneImage.SetActive(true);
                this.twoPathSignFirst.SetActive(false);
                this.twoPathSignSecond.SetActive(false);
                this.threePathSignFirst.SetActive(false);
                this.threePathSignSecond.SetActive(false);
                this.threePathSignThird.SetActive(false);
                this.linkTextText.text = "https://tinyurl.com/msuITEdTech";
                this.previousPath = "B";
                this.forestMusic.Stop();
                this.ITAndEdTechMusic.Play();
                if (!this.wentBack)
                {
                    this.prevChoiceIDHolder = this.prevChoiceID;
                    this.prevPathList.Add(this.prevChoiceIDHolder);
                }
                else
                    this.wentBack = false;
                this.prevChoiceID = 10;
                this.StartCoroutine((IEnumerator)this.TypeText());
            }
        }
        else if (this.numberOfDecisions == 2 && !this.fourPathActive && !this.onBPath)
        {
            if (!this.didVideoPlay && !this.cutsceneBlocker)
            {
                Cursor.lockState = CursorLockMode.Locked;
                this.mainCameraReference = GameObject.Find("Main Camera");
                this.mainCameraVideoPlayer = this.mainCameraReference.GetComponent<VideoPlayer>();
                this.mainCameraVideoPlayer.loopPointReached += new VideoPlayer.EventHandler(this.OnVideoFinished);
                this.prevPathForVideo = "no";
                this.mainCameraVideoPlayer.Play();
                this.cutsceneBlocker = true;
            }
            else
            {
                this.typingTextBubbleText.text = "";
                this.guySprite.SetActive(false);
                this.guyHappySprite.SetActive(false);
                this.guyCastingSprite.SetActive(false);
                this.guyHoldingStaffSprite.SetActive(true);
                this.textBubble.SetActive(true);
                this.StopCurrentAudioClips();
                this.textBubbleText.text = "Looking for workshop-style training?";
                this.ttsClipWorkshop1.Play();
                this.matthiasTextAmount = 29;
                this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                this.twoPathSign.SetActive(false);
                this.threePathSign.SetActive(false);
                ++this.numberOfDecisions;
                this.yesButton.SetActive(false);
                this.noButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.fourthButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.twoPathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.placeHolderBackground.SetActive(false);
                this.CTLIZoneImage.SetActive(true);
                this.twoPathSignFirst.SetActive(false);
                this.twoPathSignSecond.SetActive(false);
                this.threePathSignFirst.SetActive(false);
                this.threePathSignSecond.SetActive(false);
                this.threePathSignThird.SetActive(false);
                this.linkTextText.text = "https://teachingcenter.msu.edu/consultations";
                this.previousPath = "B";
                this.forestMusic.Stop();
                this.CTLIMusic.Play();
                if (!this.wentBack)
                {
                    this.prevChoiceIDHolder = this.prevChoiceID;
                    this.prevPathList.Add(this.prevChoiceIDHolder);
                }
                else
                    this.wentBack = false;
                this.prevChoiceID = 11;
                this.StartCoroutine((IEnumerator)this.TypeText());
            }
        }
        else
        {
            if (!this.fourPathActive)
                return;
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(true);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Looks like you will need to contact LTD’s D2L Specialist about your inquiry!";
            this.ttsClipD2LB1.Play();
            this.matthiasTextAmount = 10;
            this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            this.currentEmailPath = "halicks@broad.msu.edu";
            this.twoPathSign.SetActive(false);
            this.threePathSign.SetActive(false);
            this.yesButton.SetActive(false);
            this.noButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.fourthButton.SetActive(false);
            this.twoPathImage.SetActive(false);
            this.threePathImage.SetActive(false);
            this.placeHolderBackground.SetActive(false);
            this.d2LCourseBuildHouse.SetActive(true);
            this.accessibilityHouse.SetActive(false);
            this.multimediaHouse.SetActive(false);
            this.redevelopCourseHouse.SetActive(false);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
            this.bigTownBackground.SetActive(false);
            this.bigTownLeftMostSign.SetActive(false);
            this.bigTownLeftMiddleSign.SetActive(false);
            this.bigTownRightMiddleSign.SetActive(false);
            this.bigTownRightMostSign.SetActive(false);
            this.bigTownLeftMostSignHover.SetActive(false);
            this.bigTownLeftMiddleSignHover.SetActive(false);
            this.bigTownRightMiddleSignHover.SetActive(false);
            this.bigTownRightMostSignHover.SetActive(false);
            ++this.numberOfDecisions;
            this.previousPath = "B";
            if (!this.wentBack)
            {
                this.prevChoiceIDHolder = this.prevChoiceID;
                this.prevPathList.Add(this.prevChoiceIDHolder);
            }
            else
                this.wentBack = false;
            this.prevChoiceID = 12;
            this.StartCoroutine((IEnumerator)this.TypeText());
        }
    }

    public void Continue()
    {
        this.startButton.SetActive(false);
        this.creditsButton.SetActive(false);
        this.exitButton.SetActive(false);
        this.backButton.SetActive(false);
        this.startButtonHover.SetActive(false);
        this.creditsButtonHover.SetActive(false);
        this.exitButtonHover.SetActive(false);
        this.backButtonHover.SetActive(false);
        this.typingTextBubbleText.text = "";
        this.guyHappySprite.SetActive(true);
        this.textBubble.SetActive(true);
        this.StopCurrentAudioClips();
        this.textBubbleText.text = "Greetings traveler!";
        if (!this.firstTTSClipPlayed)
        {
            this.ttsClip1.Play();
            this.firstTTSClipPlayed = true;
        }
        this.matthiasTextAmount = -2;
        ++this.matthiasTextAmount;
        this.yesButton.transform.localPosition = new Vector3(-10f, 200f, 0.0f);
        this.noButton.transform.localPosition = new Vector3(615f, -180f, 0.0f);
        this.thirdButton.transform.localPosition = new Vector3(-265f, -30f, 0.0f);
        this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -16f);
        this.twoPathSign.SetActive(false);
        this.yesButtonText.text = "A: Is your question about developing course content or digital accessibility?";
        this.noButtonText.text = "B: Is your question about technology?";
        this.thirdButtonText.text = "C: Is your question about teaching practices, exploring, student feedback, or troubleshooting?";
        this.continueButton.SetActive(false);
        this.twoPathImage.SetActive(false);
        this.threePathImage.SetActive(true);
        this.placeHolderBackground.SetActive(false);
        this.twoPathSignFirst.SetActive(false);
        this.twoPathSignSecond.SetActive(false);
        this.threePathSignFirst.SetActive(false);
        this.threePathSignSecond.SetActive(false);
        this.threePathSignThird.SetActive(false);
        this.noButtonText.fontSize = 13f;
        this.yesButtonText.fontSize = 13f;
        this.thirdButtonText.margin = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        this.numberOfDecisions = 0;
        this.onBPath = false;
        this.fourPathActive = false;
        this.wentBack = false;
        this.prevChoiceID = 0;
        this.prevChoiceIDHolder = 0;
        if (!this.forestMusic.isPlaying)
        {
            this.forestMusic.Play();
            this.ITAndEdTechMusic.Stop();
            this.CTLIMusic.Stop();
            this.LTDMusic.Stop();
        }
        this.StartCoroutine((IEnumerator)this.TypeText());
    }

    public void Third()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf)
            return;
        if (this.fourPathActive)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(true);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Looks like you will need to contact LTD’s Multimedia Coordinator about that question!";
            this.ttsClipMultimedia1.Play();
            this.currentEmailPath = "basset44@msu.edu";
            this.matthiasTextAmount = 10;
            this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            this.twoPathSign.SetActive(false);
            this.threePathSign.SetActive(false);
            this.yesButton.SetActive(false);
            this.noButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.fourthButton.SetActive(false);
            this.twoPathImage.SetActive(false);
            this.threePathImage.SetActive(false);
            this.placeHolderBackground.SetActive(false);
            this.d2LCourseBuildHouse.SetActive(false);
            this.accessibilityHouse.SetActive(false);
            this.multimediaHouse.SetActive(false);
            this.redevelopCourseHouse.SetActive(true);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
            this.bigTownBackground.SetActive(false);
            this.bigTownLeftMostSign.SetActive(false);
            this.bigTownLeftMiddleSign.SetActive(false);
            this.bigTownRightMiddleSign.SetActive(false);
            this.bigTownRightMostSign.SetActive(false);
            this.bigTownLeftMostSignHover.SetActive(false);
            this.bigTownLeftMiddleSignHover.SetActive(false);
            this.bigTownRightMiddleSignHover.SetActive(false);
            this.bigTownRightMostSignHover.SetActive(false);
            ++this.numberOfDecisions;
            this.previousPath = "C";
            if (!this.wentBack)
            {
                this.prevChoiceIDHolder = this.prevChoiceID;
                this.prevPathList.Add(this.prevChoiceIDHolder);
            }
            else
                this.wentBack = false;
            this.prevChoiceID = 13;
            this.StartCoroutine((IEnumerator)this.TypeText());
        }
        else if (this.numberOfDecisions == 0 && !this.fourPathActive && !this.onBPath)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(true);
            this.textBubble.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "There are quite a few talents who can help with your type of question.";
            this.ttsClipCPathStart1.Play();
            this.matthiasTextAmount = 12;
            this.yesButton.transform.localPosition = new Vector3(-10f, 200f, 0.0f);
            this.noButton.transform.localPosition = new Vector3(615f, -180f, 0.0f);
            this.thirdButton.transform.localPosition = new Vector3(-265f, -30f, 0.0f);
            this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -16f);
            this.twoPathSign.SetActive(false);
            this.threePathSign.SetActive(false);
            this.yesButtonText.text = "A: Are you exploring new teaching practices";
            this.noButtonText.text = "B: Are you trying to evaluate student feedback?";
            this.thirdButtonText.text = "C: Are you trying to gain feedback on your existing course?";
            this.yesButton.SetActive(false);
            this.noButton.SetActive(false);
            this.thirdButton.SetActive(false);
            this.onBPath = false;
            ++this.numberOfDecisions;
            this.twoPathImage.SetActive(false);
            this.threePathImage.SetActive(true);
            this.placeHolderBackground.SetActive(false);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
            this.previousPath = "C";
            if (!this.wentBack)
            {
                this.prevChoiceIDHolder = this.prevChoiceID;
                this.prevPathList.Add(this.prevChoiceIDHolder);
            }
            else
                this.wentBack = false;
            this.prevChoiceID = 14;
            this.StartCoroutine((IEnumerator)this.TypeText());
        }
        else if (this.numberOfDecisions == 1 && !this.fourPathActive && this.onBPath)
        {
            if (!this.didVideoPlay && !this.cutsceneBlocker)
            {
                Cursor.lockState = CursorLockMode.Locked;
                this.mainCameraReference = GameObject.Find("Main Camera");
                this.mainCameraVideoPlayer = this.mainCameraReference.GetComponent<VideoPlayer>();
                this.mainCameraVideoPlayer.loopPointReached += new VideoPlayer.EventHandler(this.OnVideoFinished);
                this.prevPathForVideo = "third";
                this.mainCameraVideoPlayer.Play();
                this.cutsceneBlocker = true;
            }
            else
            {
                this.typingTextBubbleText.text = "";
                this.guySprite.SetActive(true);
                this.guyHappySprite.SetActive(false);
                this.guyCastingSprite.SetActive(false);
                this.guyHoldingStaffSprite.SetActive(false);
                this.textBubble.SetActive(true);
                this.StopCurrentAudioClips();
                this.textBubbleText.text = "You will need to contact the MSU IT Team about your concerns.";
                this.ttsClipCMSUIT1.Play();
                this.matthiasTextAmount = 20;
                this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                this.twoPathSign.SetActive(false);
                this.threePathSign.SetActive(false);
                this.yesButton.SetActive(false);
                this.noButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.fourthButton.SetActive(false);
                ++this.numberOfDecisions;
                this.twoPathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.placeHolderBackground.SetActive(false);
                this.MSUITZoneImage.SetActive(true);
                this.twoPathSignFirst.SetActive(false);
                this.twoPathSignSecond.SetActive(false);
                this.threePathSignFirst.SetActive(false);
                this.threePathSignSecond.SetActive(false);
                this.threePathSignThird.SetActive(false);
                this.linkTextText.text = "https://tech.msu.edu/help-and-support/";
                this.previousPath = "C";
                this.forestMusic.Stop();
                this.ITAndEdTechMusic.Play();
                if (!this.wentBack)
                {
                    this.prevChoiceIDHolder = this.prevChoiceID;
                    this.prevPathList.Add(this.prevChoiceIDHolder);
                }
                else
                    this.wentBack = false;
                this.prevChoiceID = 15;
                this.StartCoroutine((IEnumerator)this.TypeText());
            }
        }
        else
        {
            if (this.numberOfDecisions != 1 || this.fourPathActive || this.onBPath)
                return;
            if (!this.didVideoPlay && !this.cutsceneBlocker)
            {
                Cursor.lockState = CursorLockMode.Locked;
                this.mainCameraReference = GameObject.Find("Main Camera");
                this.mainCameraVideoPlayer = this.mainCameraReference.GetComponent<VideoPlayer>();
                this.mainCameraVideoPlayer.loopPointReached += new VideoPlayer.EventHandler(this.OnVideoFinished);
                this.prevPathForVideo = "third";
                this.mainCameraVideoPlayer.Play();
                this.cutsceneBlocker = true;
            }
            else
            {
                this.typingTextBubbleText.text = "";
                this.guySprite.SetActive(false);
                this.guyHappySprite.SetActive(true);
                this.guyCastingSprite.SetActive(false);
                this.guyHoldingStaffSprite.SetActive(false);
                this.textBubble.SetActive(true);
                this.StopCurrentAudioClips();
                this.textBubbleText.text = "Looking to gain feedback on your existing course?";
                this.ttsClipFeedback1.Play();
                this.matthiasTextAmount = 32 /*0x20*/;
                this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                this.twoPathSign.SetActive(false);
                this.threePathSign.SetActive(false);
                this.yesButton.SetActive(false);
                this.noButton.SetActive(false);
                this.thirdButton.SetActive(false);
                this.fourthButton.SetActive(false);
                ++this.numberOfDecisions;
                this.twoPathImage.SetActive(false);
                this.threePathImage.SetActive(false);
                this.placeHolderBackground.SetActive(false);
                this.CTLIZoneImage.SetActive(true);
                this.twoPathSignFirst.SetActive(false);
                this.twoPathSignSecond.SetActive(false);
                this.threePathSignFirst.SetActive(false);
                this.threePathSignSecond.SetActive(false);
                this.threePathSignThird.SetActive(false);
                this.linkTextText.text = "https://teachingcenter.msu.edu/consultations";
                this.previousPath = "C";
                this.forestMusic.Stop();
                this.CTLIMusic.Play();
                if (!this.wentBack)
                {
                    this.prevChoiceIDHolder = this.prevChoiceID;
                    this.prevPathList.Add(this.prevChoiceIDHolder);
                }
                else
                    this.wentBack = false;
                this.prevChoiceID = 16 /*0x10*/;
                this.StartCoroutine((IEnumerator)this.TypeText());
            }
        }
    }

    public void Fourth()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf)
            return;
        this.typingTextBubbleText.text = "";
        this.guySprite.SetActive(false);
        this.guyHappySprite.SetActive(true);
        this.guyCastingSprite.SetActive(false);
        this.guyHoldingStaffSprite.SetActive(false);
        this.textBubble.SetActive(true);
        this.StopCurrentAudioClips();
        this.textBubbleText.text = "Looks like you will need to contact LTD’s Accessibility and Quality Matters expert about your Inquiry!";
        this.ttsClipQM1.Play();
        this.currentEmailPath = "wellman9@msu.edu";
        this.matthiasTextAmount = 10;
        this.yesButton.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        this.twoPathSign.SetActive(false);
        this.threePathSign.SetActive(false);
        this.yesButton.SetActive(false);
        this.noButton.SetActive(false);
        this.thirdButton.SetActive(false);
        this.fourthButton.SetActive(false);
        this.twoPathImage.SetActive(false);
        this.threePathImage.SetActive(false);
        this.placeHolderBackground.SetActive(false);
        this.d2LCourseBuildHouse.SetActive(false);
        this.accessibilityHouse.SetActive(true);
        this.multimediaHouse.SetActive(false);
        this.redevelopCourseHouse.SetActive(false);
        this.twoPathSignFirst.SetActive(false);
        this.twoPathSignSecond.SetActive(false);
        this.threePathSignFirst.SetActive(false);
        this.threePathSignSecond.SetActive(false);
        this.threePathSignThird.SetActive(false);
        this.bigTownBackground.SetActive(false);
        this.bigTownLeftMostSign.SetActive(false);
        this.bigTownLeftMiddleSign.SetActive(false);
        this.bigTownRightMiddleSign.SetActive(false);
        this.bigTownRightMostSign.SetActive(false);
        this.bigTownLeftMostSignHover.SetActive(false);
        this.bigTownLeftMiddleSignHover.SetActive(false);
        this.bigTownRightMiddleSignHover.SetActive(false);
        this.bigTownRightMostSignHover.SetActive(false);
        ++this.numberOfDecisions;
        this.previousPath = "D";
        if (!this.wentBack)
        {
            this.prevChoiceIDHolder = this.prevChoiceID;
            this.prevPathList.Add(this.prevChoiceIDHolder);
        }
        else
            this.wentBack = false;
        this.prevChoiceID = 17;
        this.StartCoroutine((IEnumerator)this.TypeText());
    }

    public void FirstButtonHovered()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf)
            return;
        if (this.twoPathSign.activeSelf)
        {
            this.twoPathSign.SetActive(false);
            this.twoPathSignFirst.SetActive(true);
            this.twoPathSignSecond.SetActive(false);
        }
        if (this.threePathSign.activeSelf)
        {
            this.threePathSign.SetActive(false);
            this.threePathSignFirst.SetActive(true);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
        }
        if (!this.bigTownLeftMostSign.activeSelf)
            return;
        this.bigTownLeftMostSign.SetActive(false);
        this.bigTownLeftMostSignHover.SetActive(true);
    }

    public void SecondButtonHovered()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf)
            return;
        if (this.twoPathSign.activeSelf)
        {
            this.twoPathSign.SetActive(false);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(true);
        }
        if (this.threePathSign.activeSelf)
        {
            this.threePathSign.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(true);
            this.threePathSignThird.SetActive(false);
        }
        if (!this.bigTownLeftMiddleSign.activeSelf)
            return;
        this.bigTownLeftMiddleSign.SetActive(false);
        this.bigTownLeftMiddleSignHover.SetActive(true);
    }

    public void ThirdButtonHovered()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf)
            return;
        if (this.threePathSign.activeSelf)
        {
            this.threePathSign.SetActive(false);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(true);
        }
        if (!this.bigTownRightMiddleSign.activeSelf)
            return;
        this.bigTownRightMiddleSign.SetActive(false);
        this.bigTownRightMiddleSignHover.SetActive(true);
    }

    public void FourthButtonHovered()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf || !this.bigTownRightMostSign.activeSelf)
            return;
        this.bigTownRightMostSign.SetActive(false);
        this.bigTownRightMostSignHover.SetActive(true);
    }

    public void ButtonDehovered()
    {
        if (!this.twoPathSign.activeSelf && (this.twoPathSignFirst.activeSelf || this.twoPathSignSecond.activeSelf))
        {
            this.twoPathSign.SetActive(true);
            this.twoPathSignFirst.SetActive(false);
            this.twoPathSignSecond.SetActive(false);
        }
        if (!this.threePathSign.activeSelf && (this.threePathSignFirst.activeSelf || this.threePathSignSecond.activeSelf || this.threePathSignThird.activeSelf))
        {
            this.threePathSign.SetActive(true);
            this.threePathSignFirst.SetActive(false);
            this.threePathSignSecond.SetActive(false);
            this.threePathSignThird.SetActive(false);
        }
        if (!this.bigTownLeftMiddleSignHover.activeSelf && !this.bigTownLeftMostSignHover.activeSelf && !this.bigTownRightMiddleSignHover.activeSelf && !this.bigTownRightMostSignHover.activeSelf)
            return;
        this.bigTownLeftMostSign.SetActive(true);
        this.bigTownLeftMostSignHover.SetActive(false);
        this.bigTownLeftMiddleSign.SetActive(true);
        this.bigTownLeftMiddleSignHover.SetActive(false);
        this.bigTownRightMiddleSign.SetActive(true);
        this.bigTownRightMiddleSignHover.SetActive(false);
        this.bigTownRightMostSign.SetActive(true);
        this.bigTownRightMostSignHover.SetActive(false);
    }

    public void ScrollHovered()
    {
        if (!this.scrollClosed.activeSelf || this.scrollOpened.activeSelf)
            return;
        this.scrollClosed.SetActive(false);
        this.scrollOpened.SetActive(true);
        this.clickHereText.SetActive(true);
        this.scrollOpenSound.Play();
    }

    public void ScrollDehovered()
    {
        if (this.scrollClosed.activeSelf || !this.scrollOpened.activeSelf)
            return;
        this.scrollClosed.SetActive(true);
        this.scrollOpened.SetActive(false);
        this.linkText.SetActive(false);
        this.clickHereText.SetActive(false);
    }

    public void ScrollClicked()
    {
        this.OpenWebsite(this.linkTextText.text);
        this.SendEmail(this.currentEmailPath);
    }

    public void OpenWebsite(string url)
    {
        if (!(url != ""))
            return;
        Application.OpenURL(url);
    }

    public void Credits()
    {
        this.startButton.SetActive(false);
        this.creditsButton.SetActive(false);
        this.exitButton.SetActive(false);
        this.backButton.SetActive(true);
        this.creditsText.SetActive(true);
        this.startButtonHover.SetActive(false);
        this.creditsButtonHover.SetActive(false);
        this.exitButtonHover.SetActive(false);
    }

    public void Back()
    {
        this.startButton.SetActive(true);
        this.creditsButton.SetActive(true);
        this.exitButton.SetActive(true);
        this.backButton.SetActive(false);
        this.creditsText.SetActive(false);
        this.backButtonHover.SetActive(false);
    }

    public void Exit() => Application.Quit();

    public void StartHover()
    {
        this.startButton.SetActive(false);
        this.startButtonHover.SetActive(true);
    }

    public void CreditsHover()
    {
        this.creditsButton.SetActive(false);
        this.creditsButtonHover.SetActive(true);
    }

    public void ExitHover()
    {
        this.exitButton.SetActive(false);
        this.exitButtonHover.SetActive(true);
    }

    public void BackHover()
    {
        this.backButton.SetActive(false);
        this.backButtonHover.SetActive(true);
    }

    public void TitleButtonDehover()
    {
        if (this.creditsText.activeSelf)
            return;
        this.startButton.SetActive(true);
        this.creditsButton.SetActive(true);
        this.exitButton.SetActive(true);
        this.startButtonHover.SetActive(false);
        this.creditsButtonHover.SetActive(false);
        this.exitButtonHover.SetActive(false);
    }

    public void BackButtonDehover()
    {
        if (!this.creditsText.activeSelf)
            return;
        this.backButton.SetActive(true);
        this.backButtonHover.SetActive(false);
    }

    public void GoBack()
    {
        if (this.guySprite.activeSelf || this.guyHappySprite.activeSelf || this.guyCastingSprite.activeSelf || this.guyHoldingStaffSprite.activeSelf || this.numberOfDecisions == 0)
            return;
        this.currentEmailPath = "FailSafePlaceholder@example.com";
        this.twoPathSign.SetActive(false);
        this.threePathSign.SetActive(false);
        this.yesButton.SetActive(false);
        this.noButton.SetActive(false);
        this.thirdButton.SetActive(false);
        this.fourthButton.SetActive(false);
        this.twoPathImage.SetActive(false);
        this.threePathImage.SetActive(false);
        this.placeHolderBackground.SetActive(false);
        this.MSUITZoneImage.SetActive(false);
        this.LTDZoneImage.SetActive(false);
        this.EdTechZoneImage.SetActive(false);
        this.CTLIZoneImage.SetActive(false);
        this.d2LCourseBuildHouse.SetActive(false);
        this.accessibilityHouse.SetActive(false);
        this.multimediaHouse.SetActive(false);
        this.redevelopCourseHouse.SetActive(false);
        this.twoPathSignFirst.SetActive(false);
        this.twoPathSignSecond.SetActive(false);
        this.threePathSignFirst.SetActive(false);
        this.threePathSignSecond.SetActive(false);
        this.threePathSignThird.SetActive(false);
        this.bigTownBackground.SetActive(false);
        this.bigTownLeftMostSign.SetActive(false);
        this.bigTownLeftMiddleSign.SetActive(false);
        this.bigTownRightMiddleSign.SetActive(false);
        this.bigTownRightMostSign.SetActive(false);
        this.bigTownLeftMostSignHover.SetActive(false);
        this.bigTownLeftMiddleSignHover.SetActive(false);
        this.bigTownRightMiddleSignHover.SetActive(false);
        this.bigTownRightMostSignHover.SetActive(false);
        this.scrollClosed.SetActive(false);
        this.wentBack = true;
        if (this.prevPathList.Count > 0)
        {
            int prevPath = this.prevPathList[this.prevPathList.Count - 1];
            this.prevPathList.RemoveAt(this.prevPathList.Count - 1);
            switch (prevPath)
            {
                case 0:
                    this.Continue();
                    this.YesSkip();
                    break;
                case 1:
                    this.numberOfDecisions = 0;
                    this.onBPath = false;
                    this.Yes();
                    break;
                case 2:
                    this.numberOfDecisions = 1;
                    this.onBPath = true;
                    this.fourPathActive = false;
                    this.Yes();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 3:
                    this.numberOfDecisions = 1;
                    this.onBPath = false;
                    this.fourPathActive = false;
                    this.Yes();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 4:
                    this.numberOfDecisions = 2;
                    this.onBPath = true;
                    this.fourPathActive = false;
                    this.Yes();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 5:
                    this.numberOfDecisions = 2;
                    this.onBPath = false;
                    this.fourPathActive = false;
                    this.Yes();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 6:
                    this.numberOfDecisions = 2;
                    this.fourPathActive = true;
                    this.Yes();
                    break;
                case 7:
                    this.numberOfDecisions = 0;
                    this.fourPathActive = false;
                    this.No();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 8:
                    this.numberOfDecisions = 1;
                    this.onBPath = true;
                    this.fourPathActive = false;
                    this.No();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 9:
                    this.numberOfDecisions = 1;
                    this.onBPath = false;
                    this.fourPathActive = false;
                    this.No();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 10:
                    this.numberOfDecisions = 2;
                    this.onBPath = true;
                    this.fourPathActive = false;
                    this.No();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 11:
                    this.numberOfDecisions = 2;
                    this.onBPath = false;
                    this.fourPathActive = false;
                    this.No();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 12:
                    this.numberOfDecisions = 2;
                    this.fourPathActive = true;
                    this.No();
                    break;
                case 13:
                    this.numberOfDecisions = 2;
                    this.fourPathActive = true;
                    this.Third();
                    break;
                case 14:
                    this.numberOfDecisions = 0;
                    this.onBPath = false;
                    this.fourPathActive = false;
                    this.Third();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 15:
                    this.numberOfDecisions = 1;
                    this.onBPath = true;
                    this.fourPathActive = false;
                    this.Third();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 16 /*0x10*/:
                    this.numberOfDecisions = 1;
                    this.onBPath = false;
                    this.fourPathActive = false;
                    this.Third();
                    if (this.forestMusic.isPlaying)
                        break;
                    this.forestMusic.Play();
                    this.ITAndEdTechMusic.Stop();
                    this.CTLIMusic.Stop();
                    this.LTDMusic.Stop();
                    break;
                case 17:
                    this.numberOfDecisions = 2;
                    this.Fourth();
                    break;
                default:
                    Debug.LogWarning((object)("Unknown backtrack value: " + prevPath.ToString()));
                    break;
            }
        }
        else
            Debug.LogWarning((object)"Tried to GoBack() but prevPathList is empty.");
    }

    public void PreviousDecisionButtonHovered()
    {
        this.prevButton.SetActive(false);
        this.prevButtonHover.SetActive(true);
    }

    public void PreviousDecisionButtonDehovered()
    {
        this.prevButton.SetActive(true);
        this.prevButtonHover.SetActive(false);
    }

    public void YesSkip()
    {
        this.textBoxYesNo.SetActive(false);
        this.matthiasTextAmount = 6;
        this.UpdateMatthiasText();
        this.yesSkipButton.SetActive(false);
        this.yesSkipButtonHover.SetActive(false);
        this.noSkipButton.SetActive(false);
        this.noSkipButtonHover.SetActive(false);
        this.threePathSign.SetActive(true);
        this.yesButton.SetActive(true);
        this.noButton.SetActive(true);
        this.thirdButton.SetActive(true);
        this.textBoxYesNo.SetActive(false);
    }

    public void NoSkip()
    {
        this.matthiasTextAmount = 1;
        this.UpdateMatthiasText();
        this.yesSkipButton.SetActive(false);
        this.yesSkipButtonHover.SetActive(false);
        this.noSkipButton.SetActive(false);
        this.noSkipButtonHover.SetActive(false);
    }

    public void YesSkipHovered()
    {
        this.yesSkipButton.SetActive(false);
        this.yesSkipButtonHover.SetActive(true);
    }

    public void NoSkipHovered()
    {
        this.noSkipButton.SetActive(false);
        this.noSkipButtonHover.SetActive(true);
    }

    public void YesSkipDehovered()
    {
        this.yesSkipButton.SetActive(true);
        this.yesSkipButtonHover.SetActive(false);
    }

    public void NoSkipDehovered()
    {
        this.noSkipButton.SetActive(true);
        this.noSkipButtonHover.SetActive(false);
    }

    public void UpdateMatthiasText()
    {
        if (this.matthiasTextAmount == -1)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(true);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Have we met before?";
            this.ttsClip2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 0)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            this.yesSkipButton.SetActive(true);
            this.noSkipButton.SetActive(true);
            this.textBoxYesNo.SetActive(true);
            this.textBubble.SetActive(false);
        }
        else if (this.matthiasTextAmount == 1)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(true);
            this.textBoxYesNo.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "My name is Matthias, and I will be your guide, an Educational Support Wizard, if you will.";
            this.ttsClip3.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 2)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "I am here to help you find where you need to go!";
            this.ttsClip4.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 3)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Think about your inquiry that you need supporting and follow the path to which your concerns best align with!";
            this.ttsClip5.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 4)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "I will get you to a team or individual that will be able to help you on your journey.";
            this.ttsClip6.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 5)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(true);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.threePathSign.SetActive(true);
            this.yesButton.SetActive(true);
            this.noButton.SetActive(true);
            this.thirdButton.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click which sign best aligns with your inquiry.";
            this.ttsClip7.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 6)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.prevButton.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 7)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(true);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "You’ve come to the right place!";
            this.ttsClipA2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 8)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(true);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Which of the following does your question best align to?";
            this.ttsClipA3.Play();
            this.bigTownLeftMostSign.SetActive(true);
            this.bigTownLeftMiddleSign.SetActive(true);
            this.bigTownRightMiddleSign.SetActive(true);
            this.bigTownRightMostSign.SetActive(true);
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 9)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            this.yesButton.SetActive(true);
            this.noButton.SetActive(true);
            this.thirdButton.SetActive(true);
            this.fourthButton.SetActive(true);
            ++this.matthiasTextAmount;
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 10)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click on the scroll to be sent to their contact information!";
            this.ttsClipRedev2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 11)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.guySprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.scrollClosed.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 12)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(true);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "But we can get more specific!";
            this.ttsClipB2.Play();
            this.threePathSign.SetActive(true);
            this.yesButton.SetActive(true);
            this.noButton.SetActive(true);
            this.thirdButton.SetActive(true);
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 13)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 14)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Look no further than the Learning Technology and Development Team!";
            this.ttsClipHelp2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 15)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click the scroll to be taken to their contacts!";
            this.ttsClipHelp3.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 16 /*0x10*/)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.scrollClosed.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 17)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(true);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Look no further than MSU EdTech!";
            this.ttsClipAssistance2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 18)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click the scroll to be taken to their contacts!";
            this.ttsClipAssistance3.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 19)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.scrollClosed.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 20)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "I can get you to their website!";
            this.ttsClipBMSUIT2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 21)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click the scroll to be sent to their contacts!";
            this.ttsClipHelp3.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 22)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.scrollClosed.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 23)
        {
            this.typingTextBubbleText.text = "";
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Look no further than the Center for Teaching and Learning Innovation!";
            this.ttsClipWorkshop2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 24)
        {
            this.typingTextBubbleText.text = "";
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click the scroll to be sent to their contacts!";
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 25)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.scrollClosed.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 26)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(true);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Look no further than the Learning Technology and Development Team!";
            this.ttsClipHelp2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 27)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click the scroll to be taken to their contacts!";
            this.ttsClipHelp3.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 28)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.scrollClosed.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 29)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(true);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Look no further than the Center for Teaching and Learning Innovation!";
            this.ttsClipWorkshop2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 30)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click the scroll to be taken to their contacts!";
            this.ttsClipHelp3.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 31 /*0x1F*/)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.scrollClosed.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else if (this.matthiasTextAmount == 32 /*0x20*/)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(true);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Look no further than the Center for Teaching and Learning Innovation!";
            this.ttsClipWorkshop2.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 33)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(true);
            this.guyHoldingStaffSprite.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "Click the scroll to be taken to their contacts!";
            this.ttsClipHelp3.Play();
            this.StartCoroutine((IEnumerator)this.TypeText());
            ++this.matthiasTextAmount;
        }
        else if (this.matthiasTextAmount == 34)
        {
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.scrollClosed.SetActive(true);
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
        else
        {
            if (this.matthiasTextAmount != 35)
                return;
            this.typingTextBubbleText.text = "";
            this.guySprite.SetActive(false);
            this.guyHappySprite.SetActive(false);
            this.guyCastingSprite.SetActive(false);
            this.guyHoldingStaffSprite.SetActive(false);
            this.textBubble.SetActive(false);
            this.StopCurrentAudioClips();
            this.textBubbleText.text = "";
            ++this.matthiasTextAmount;
            this.forestMusic.volume = 0.6f;
            this.CTLIMusic.volume = 0.6f;
            this.ITAndEdTechMusic.volume = 0.6f;
            this.LTDMusic.volume = 0.6f;
        }
    }

    public void SendEmail(string emailEntered)
    {
        string str1 = Uri.EscapeDataString("Your Subject Here");
        string str2 = Uri.EscapeDataString("Hello, this is the body of the email.");
        if (emailEntered == "basset44@msu.edu")
        {
            str1 = Uri.EscapeDataString("Support Request: Audio/Video Assistance");
            str2 = Uri.EscapeDataString("Hello, \r\n\r\nMy name is (insert name here). I selected the “Audio/Video” path in the Educational Support Wizard game on the LTD website; and would like your help creating video or audio content. Here some information about what I wish to do: \r\n\r\nWhat is this content for? [e.g., ENG 302: Advanced Composition, a podcast featuring my colleges, etc] \r\n\r\nDelivery Format: [e.g., Fully online, hybrid, asynchronous, etc.] \r\n\r\nI would like this by: [e.g., Fall 2025] \r\n\r\nCourse Link (if applicable): [Insert link to D2L or LMS shared site] \r\n\r\n \r\n\r\nI am curious if you could help me with... \r\n [ ] Recording audio/video \r\n\r\n [ ] Creating interactive modules for students/users \r\n [ ] Edit existing content \r\n [ ] Exploring content options (i.e.; animated videos, slides, interactive modules, etc) \r\n [ ] Other: [briefly describe] \r\n\r\nLet me know what next steps you'd recommend and what information you might need from me. I’d also be happy to set up a meeting with you, if that would help. \r\n\r\nThank you so much! \r\n\r\n \r\n [Faculty Name] \r\n [Department or Program] \r\n [Contact Info, if needed] ");
        }
        if (emailEntered == "wellman9@msu.edu")
        {
            str1 = Uri.EscapeDataString("Support Request: Course Quality Review Assistance ");
            str2 = Uri.EscapeDataString("Hello, \r\n\r\nMy name is (insert name here). I selected the “course quality” path in the Educational Support Wizard game on the LTD website; and would like your help reviewing a finished course. Here some information about the course: \r\n\r\nCourse Title and Code: [e.g., ENG 302: Advanced Composition] \r\n\r\nDelivery Format: [e.g., Fully online, hybrid, asynchronous, etc.] \r\n\r\nSemester/Term: [e.g., Fall 2025] \r\n\r\nCourse Link (if available): [Insert link to D2L or LMS shared site] \r\n\r\n \r\n\r\nI am curious if you could help me with... \r\n [ ] A general course quality review \r\n [ ] Alignment with [QM / internal rubric / accessibility standards] \r\n [ ] Suggestions before an external review \r\n [ ] Specific section(s) (e.g., assessments, alignment, accessibility) \r\n [ ] Other: [briefly describe] \r\n\r\nLet me know what next steps you'd recommend and what information you might need from me. I’d also be happy to set up a meeting with you, if that would help. \r\n\r\nThank you so much! \r\n\r\n[Faculty Name]  \r\n[Department or Program]  \r\n[Contact Info, if needed] ");
        }
        if (emailEntered == "benne784@broad.msu.edu")
        {
            str1 = Uri.EscapeDataString("Support Request: Interest Course Development");
            str2 = Uri.EscapeDataString("Hello, \r\n\r\nMy name is (insert name here). I selected the “Course Redevelopment” path in the Educational Support Wizard game on the LTD website; and would like your help in developing my course on D2L. Here some information about the course: \r\n\r\nCourse Title and Code? [e.g., ENG 302: Advanced Composition, a podcast featuring my colleges, etc] \r\n\r\nDelivery Format: [e.g., Fully online, hybrid, asynchronous, etc.] \r\n\r\nCourse start: [e.g., Fall 2025] \r\n\r\nCourse Link (if applicable): [Insert link to D2L or LMS shared site] \r\n\r\n \r\n\r\nI am curious if you could help me with... \r\n [ ] Interest Selecting/Learning about tools \r\n\r\n [ ] Interest in D2L training \r\n [ ] Exploring course material \r\n [ ] Other: [briefly describe] \r\n\r\nLet me know what next steps you'd recommend and what information you might need from me. I’d also be happy to set up a meeting with you, if that would help. \r\n\r\nThank you so much! \r\n\r\n[Faculty Name]  \r\n[Department or Program]  \r\n[Contact Info, if needed] ");
        }
        if (emailEntered == "halicks@broad.msu.edu")
        {
            str1 = Uri.EscapeDataString("Support Request: D2L Assistance");
            str2 = Uri.EscapeDataString("My name is (insert name here). I selected the “D2L” path in the Educational Support Wizard game on the LTD website; and would like D2L support. Here some information about the course(s) I am currently working on: \r\n\r\nCourse Title and Code: [e.g., ENG 302: Advanced Composition] \r\n\r\nDelivery Format: [e.g., Fully online, hybrid, asynchronous, etc.] \r\n\r\nSemester/Term: [e.g., Fall 2025] \r\n\r\nCourse Link (if available): [Insert link to D2L or LMS shared site] \r\n\r\n \r\n\r\nI am curious if you could help me with... \r\n [ ] Building this course in D2L \r\n\r\n [ ] Embedding a video into my D2L page \r\n [ ] Adding specific widgets to my pre-existing course \r\n [ ] Suggestions for my D2L page \r\n [ ] Other: [briefly describe] \r\n\r\nLet me know what next steps you'd recommend and what information you might need from me. I’d also be happy to set up a meeting with you, if that would help. \r\n\r\nThank you so much! \r\n\r\n[Faculty Name]  \r\n[Department or Program]  \r\n[Contact Info, if needed] ");
        }
        string url = $"mailto:ltd.broad@msu.edu?subject={str1}&body={str2}";
        if (!(str1 != Uri.EscapeDataString("Your Subject Here")))
            return;
        Application.OpenURL(url);
    }

    public IEnumerator TypeText()
    {
        this.isTyping = true;
        this.forestMusic.volume = 0.3f;
        this.CTLIMusic.volume = 0.3f;
        this.ITAndEdTechMusic.volume = 0.3f;
        this.LTDMusic.volume = 0.3f;
        for (int i = 0; i < this.textBubbleText.text.Length; ++i)
        {
            this.typingTextBubbleText.text = this.textBubbleText.text.Substring(0, i + 1);
            yield return (object)new WaitForSeconds(this.typingSpeed);
        }
        this.isTyping = false;
    }

    public void SkipTyping()
    {
        this.StopAllCoroutines();
        this.typingTextBubbleText.text = this.textBubbleText.text;
        this.isTyping = false;
    }

    public void StopCurrentAudioClips()
    {
        if (this.ttsClip1.isPlaying)
            this.ttsClip1.Stop();
        if (this.ttsClip2.isPlaying)
            this.ttsClip2.Stop();
        if (this.ttsClip3.isPlaying)
            this.ttsClip3.Stop();
        if (this.ttsClip4.isPlaying)
            this.ttsClip4.Stop();
        if (this.ttsClip5.isPlaying)
            this.ttsClip5.Stop();
        if (this.ttsClip6.isPlaying)
            this.ttsClip6.Stop();
        if (this.ttsClip7.isPlaying)
            this.ttsClip7.Stop();
        if (this.ttsClipA1.isPlaying)
            this.ttsClipA1.Stop();
        if (this.ttsClipA2.isPlaying)
            this.ttsClipA2.Stop();
        if (this.ttsClipA3.isPlaying)
            this.ttsClipA3.Stop();
        if (this.ttsClipRedev1.isPlaying)
            this.ttsClipRedev1.Stop();
        if (this.ttsClipRedev2.isPlaying)
            this.ttsClipRedev2.Stop();
        if (this.ttsClipD2LB1.isPlaying)
            this.ttsClipD2LB1.Stop();
        if (this.ttsClipD2LB2.isPlaying)
            this.ttsClipD2LB2.Stop();
        if (this.ttsClipMultimedia1.isPlaying)
            this.ttsClipMultimedia1.Stop();
        if (this.ttsClipQM1.isPlaying)
            this.ttsClipQM1.Stop();
        if (this.ttsClipB1.isPlaying)
            this.ttsClipB1.Stop();
        if (this.ttsClipB2.isPlaying)
            this.ttsClipB2.Stop();
        if (this.ttsClipATool1.isPlaying)
            this.ttsClipATool1.Stop();
        if (this.ttsClipHelp1.isPlaying)
            this.ttsClipHelp1.Stop();
        if (this.ttsClipHelp2.isPlaying)
            this.ttsClipHelp2.Stop();
        if (this.ttsClipHelp3.isPlaying)
            this.ttsClipHelp3.Stop();
        if (this.ttsClipAssistance1.isPlaying)
            this.ttsClipAssistance1.Stop();
        if (this.ttsClipAssistance2.isPlaying)
            this.ttsClipAssistance2.Stop();
        if (this.ttsClipAssistance3.isPlaying)
            this.ttsClipAssistance3.Stop();
        if (this.ttsClipBMSUIT1.isPlaying)
            this.ttsClipBMSUIT1.Stop();
        if (this.ttsClipBMSUIT2.isPlaying)
            this.ttsClipBMSUIT2.Stop();
        if (this.ttsClipCMSUIT1.isPlaying)
            this.ttsClipCMSUIT1.Stop();
        if (this.ttsClipCPathStart1.isPlaying)
            this.ttsClipCPathStart1.Stop();
        if (this.ttsClipABTraining1.isPlaying)
            this.ttsClipABTraining1.Stop();
        if (this.ttsClipOneOnOne1.isPlaying)
            this.ttsClipOneOnOne1.Stop();
        if (this.ttsClipWorkshop1.isPlaying)
            this.ttsClipWorkshop1.Stop();
        if (this.ttsClipWorkshop2.isPlaying)
            this.ttsClipWorkshop2.Stop();
        if (!this.ttsClipFeedback1.isPlaying)
            return;
        this.ttsClipFeedback1.Stop();
    }
}
