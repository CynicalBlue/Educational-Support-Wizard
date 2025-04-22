using System.Globalization;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor.Animations;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Main: MonoBehaviour
{
    public int numberOfDecisions = 0;
    public bool onBPath;
    public bool fourPathActive;
    public string currentPathName = "placeholder";

    public GameObject yesButton;
    public GameObject noButton;
    public GameObject thirdButton;
    public GameObject fourthButton;
    public GameObject continueButton;
    public TMP_Text mainTextObject;

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
    public float typingSpeed = 0.05f; // 0.05f is base
    public bool isTyping = false;
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

    public GameObject mainTextReference;

    public AudioSource voiceClip;

    private void Awake()
    {
        mainTextObject.text = "Welcome to the Educational Support Wizard";
        continueButton.SetActive(true);
        yesButtonText = yesButton.GetComponentInChildren<TMP_Text>();
        noButtonText = noButton.GetComponentInChildren<TMP_Text>();
        thirdButtonText = thirdButton.GetComponentInChildren<TMP_Text>();
        fourthButtonText = fourthButton.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true && (guySprite.activeSelf == true || guyHappySprite.activeSelf == true || guyCastingSprite.activeSelf == true || guyHoldingStaffSprite.activeSelf == true) && isTyping)
        {
            SkipTyping();
            return;
        }
        if (Input.GetMouseButtonDown(0) == true && (guySprite.activeSelf == true || guyHappySprite.activeSelf == true || guyCastingSprite.activeSelf == true || guyHoldingStaffSprite.activeSelf == true) && !isTyping)
        {
            UpdateMatthiasText();
            return;
        }
    }

    public void Yes()
    {
        if (guySprite.activeSelf == false && guyHappySprite.activeSelf == false && guyCastingSprite.activeSelf == false && guyHoldingStaffSprite.activeSelf == false)
        {
            if (numberOfDecisions == 0)
            {
                mainTextReference.SetActive(false);
                mainTextObject.text = "LTD Zone: Q4a: Which of the following does your question best align to?";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(true);
                textBubble.SetActive(true);
                textBubbleText.text = "Looks like you want to contact someone from the Learning Technology and Development team.";
                matthiasTextAmount = 7;
                yesButton.transform.localPosition = new Vector3(-740, -250, 0);
                noButton.transform.localPosition = new Vector3(500, -390, 0);
                thirdButton.transform.localPosition = new Vector3(50, -160, 0);
                fourthButton.transform.localPosition = new Vector3(805, -380, 0);
                mainTextObject.rectTransform.localPosition = new Vector3(0, 305, 0);
                noButtonText.fontSize = 11;
                thirdButtonText.fontSize = 11;
                thirdButtonText.margin = new Vector4(47, 0, 50, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                numberOfDecisions++;
                fourPathActive = true;
                yesButtonText.text = "Audio/Video Creation";
                noButtonText.text = "D2L course building";
                thirdButtonText.text = "Redeveloping your course";
                fourthButtonText.text = "The accessibility of your existing course";
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                bigTownBackground.SetActive(true);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 1 && onBPath == true && fourPathActive != true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(true);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false);
                textBubble.SetActive(true);
                textBubbleText.text = "Are you still in need of deciding an appropriate tool?";
                matthiasTextAmount = 35;
                yesButton.transform.localPosition = new Vector3(0, 240, 0);
                noButton.transform.localPosition = new Vector3(825, -120, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                mainTextObject.text = "LTD/EdTech Zone: Q6a: Are you still in need of deciding an appropriate tool?";
                numberOfDecisions++;
                yesButtonText.text = "Yes, I need help selecting.";
                noButtonText.text = "No, I need use assistance.";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                twoPathImage.SetActive(true);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 1 && onBPath != true && fourPathActive != true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(true);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false);
                textBubble.SetActive(true);
                textBubbleText.text = "Were you looking for a workshop style training or a one-on-one consultation?";
                matthiasTextAmount = 35;
                yesButton.transform.localPosition = new Vector3(0, 240, 0);
                noButton.transform.localPosition = new Vector3(825, -120, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                mainTextObject.text = "LTD/CTLI Zone: Q6b: Were you looking for a workshop style training or a one-on-one consultation?";
                numberOfDecisions++;
                yesButtonText.text = "One-on-one";
                noButtonText.text = "Workshop";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                thirdButton.SetActive(false);
                twoPathImage.SetActive(true);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 2 && fourPathActive != true && onBPath == true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(true);
                textBubble.SetActive(true);
                textBubbleText.text = "Need help selecting an appropriate tool for your course?";
                matthiasTextAmount = 14;
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Contact the LTD team: You will be linked to the Contact Us Page.";
                numberOfDecisions++;
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                thirdButton.SetActive(false);
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                LTDZoneImage.SetActive(true);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 2 && fourPathActive != true && onBPath == false)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(true);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false);
                textBubble.SetActive(true);
                textBubbleText.text = "Looking for a one-on-one style consultation?";
                matthiasTextAmount = 26;
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Contact the LTD team.";
                numberOfDecisions++;
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                thirdButton.SetActive(false);
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                LTDZoneImage.SetActive(true);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (fourPathActive == true)
            {
                mainTextReference.SetActive(false);
                mainTextObject.text = "Please contact our Multimedia Coordinator for this question (insert Andy email here?)";
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(true);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false);
                textBubble.SetActive(true);
                textBubbleText.text = "Looks like you will need to contact LTD’s Multimedia Coordinator about that question!";
                matthiasTextAmount = 10;
                mainTextObject.rectTransform.localPosition = new Vector3(0, 173, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                d2LCourseBuildHouse.SetActive(false);
                accessibilityHouse.SetActive(false);
                multimediaHouse.SetActive(true);
                redevelopCourseHouse.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                bigTownBackground.SetActive(false);
                bigTownLeftMostSign.SetActive(false);
                bigTownLeftMiddleSign.SetActive(false);
                bigTownRightMiddleSign.SetActive(false);
                bigTownRightMostSign.SetActive(false);
                bigTownLeftMostSignHover.SetActive(false);
                bigTownLeftMiddleSignHover.SetActive(false);
                bigTownRightMiddleSignHover.SetActive(false);
                bigTownRightMostSignHover.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
        }
    }

    public void No()
    {
        if (guySprite.activeSelf == false && guyHappySprite.activeSelf == false && guyCastingSprite.activeSelf == false && guyHoldingStaffSprite.activeSelf == false)
        {
            if (numberOfDecisions == 0)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(true); 
                textBubble.SetActive(true);
                textBubbleText.text = "Ahh technology, there’s quite a few talents who can help with that.";
                matthiasTextAmount = 12;
                yesButton.transform.localPosition = new Vector3(-10, 200, 0);
                noButton.transform.localPosition = new Vector3(615, -180, 0);
                thirdButton.transform.localPosition = new Vector3(-265, -30, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, -16); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                mainTextObject.text = "";
                yesButtonText.text = "A: Is your question about how to select and us the appropriate technology?";
                noButtonText.text = "B: Is your question related to solving classroom tech installation?";
                thirdButtonText.text = "C: Is your question related to solving a general tech issue?";
                numberOfDecisions++;
                onBPath = true;
                twoPathImage.SetActive(false);
                threePathImage.SetActive(true);
                placeHolderBackground.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 1 && onBPath == true && fourPathActive != true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(true);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false); 
                textBubble.SetActive(true);
                textBubbleText.text = "You will need to contact the MSU IT Team about your inquiry.";
                matthiasTextAmount = 20;
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Contact the MSU IT Team.";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                numberOfDecisions++;
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                MSUITZoneImage.SetActive(true);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 1 && onBPath != true && fourPathActive != true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(true);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false);
                textBubble.SetActive(true);
                textBubbleText.text = "Were you looking for a workshop style training or a one-on-one consultation?";
                matthiasTextAmount = 35;
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                yesButton.transform.localPosition = new Vector3(0, 240, 0);
                noButton.transform.localPosition = new Vector3(825, -120, 0);
                twoPathSign.SetActive(true);
                threePathSign.SetActive(false);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                mainTextObject.text = "LTD/CTLI Zone: Q6b: Were you looking for a workshop style training or a one-on-one consultation?";
                numberOfDecisions++;
                yesButtonText.text = "One-on-one";
                noButtonText.text = "Workshop";
                yesButton.SetActive(true);
                noButton.SetActive(true);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                thirdButton.SetActive(false);
                twoPathImage.SetActive(true);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 2 && fourPathActive != true && onBPath == true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(true);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false);
                textBubble.SetActive(true);
                textBubbleText.text = "Need use assistance with your teaching tool?";
                matthiasTextAmount = 17;
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Please contact MSU EdTech about this Question.";
                numberOfDecisions++;
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                thirdButton.SetActive(false);
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                EdTechZoneImage.SetActive(true);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 2 && fourPathActive != true && onBPath == false)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(true);
                textBubble.SetActive(true);
                textBubbleText.text = "Looking for workshop-style training?";
                matthiasTextAmount = 29;
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Please contact CTLI about this question.";
                numberOfDecisions++;
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                thirdButton.SetActive(false);
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                CTLIZoneImage.SetActive(true);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (fourPathActive == true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(true);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false);
                textBubble.SetActive(true);
                textBubbleText.text = "Looks like you will need to contact LTD’s D2L Specialist about your inquiry!";
                matthiasTextAmount = 10;
                mainTextObject.rectTransform.localPosition = new Vector3(0, 173, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Please contact our D2L specialist for this question (insert Sue email here?)";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                d2LCourseBuildHouse.SetActive(true);
                accessibilityHouse.SetActive(false);
                multimediaHouse.SetActive(false);
                redevelopCourseHouse.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                bigTownBackground.SetActive(false);
                bigTownLeftMostSign.SetActive(false);
                bigTownLeftMiddleSign.SetActive(false);
                bigTownRightMiddleSign.SetActive(false);
                bigTownRightMostSign.SetActive(false);
                bigTownLeftMostSignHover.SetActive(false);
                bigTownLeftMiddleSignHover.SetActive(false);
                bigTownRightMiddleSignHover.SetActive(false);
                bigTownRightMostSignHover.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
        }
    }

    public void Continue()
    {
        if (mainTextObject.text == "Welcome to the Educational Support Wizard")
        {
            continueButton.SetActive(true);
            mainTextObject.text = "Brief explanation goes here";
            return;
        }
        if (mainTextObject.text == "Brief explanation goes here")
        {
            typingTextBubbleText.text = "";
            guyHappySprite.SetActive(true);
            textBubble.SetActive(true);
            textBubbleText.text = "Greetings traveler!";
            matthiasTextAmount++;
            mainTextObject.text = "";
            yesButton.transform.localPosition = new Vector3(-10, 200, 0);
            noButton.transform.localPosition = new Vector3(615, -180, 0);
            thirdButton.transform.localPosition = new Vector3(-265, -30, 0);
            yesButton.transform.localRotation = Quaternion.Euler(0, 0, -16); ;
            twoPathSign.SetActive(false);
            yesButtonText.text = "A: Is your question about developing course content or digital accessibility?";
            noButtonText.text = "B: Is your question about technology?";
            thirdButtonText.text = "C: Is your question about teaching practices, exploring, student feedback, or troubleshooting?";
            continueButton.SetActive(false);
            twoPathImage.SetActive(false);
            threePathImage.SetActive(true);
            placeHolderBackground.SetActive(false);
            twoPathSignFirst.SetActive(false);
            twoPathSignSecond.SetActive(false);
            threePathSignFirst.SetActive(false);
            threePathSignSecond.SetActive(false);
            threePathSignThird.SetActive(false);
            StartCoroutine(TypeText());
        }
    }

    public void Third()
    {
        if (guySprite.activeSelf == false && guyHappySprite.activeSelf == false && guyCastingSprite.activeSelf == false && guyHoldingStaffSprite.activeSelf == false)
        {
            if (fourPathActive == true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(true);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false); 
                textBubble.SetActive(true);
                textBubbleText.text = "Looks like you will need to contact LTD’s Learning Experience Manager about your questions!";
                matthiasTextAmount = 10;
                mainTextObject.rectTransform.localPosition = new Vector3(0, 173, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Please contact our Learning Experience Manager for this question (insert Matt email)";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                d2LCourseBuildHouse.SetActive(false);
                accessibilityHouse.SetActive(false);
                multimediaHouse.SetActive(false);
                redevelopCourseHouse.SetActive(true);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                bigTownBackground.SetActive(false);
                bigTownLeftMostSign.SetActive(false);
                bigTownLeftMiddleSign.SetActive(false);
                bigTownRightMiddleSign.SetActive(false);
                bigTownRightMostSign.SetActive(false);
                bigTownLeftMostSignHover.SetActive(false);
                bigTownLeftMiddleSignHover.SetActive(false);
                bigTownRightMiddleSignHover.SetActive(false);
                bigTownRightMostSignHover.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 0 && fourPathActive != true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(true); 
                textBubble.SetActive(true);
                textBubbleText.text = "There are quite a few talents who can help with your type of question.";
                matthiasTextAmount = 12;
                yesButton.transform.localPosition = new Vector3(-10, 200, 0);
                noButton.transform.localPosition = new Vector3(615, -180, 0);
                thirdButton.transform.localPosition = new Vector3(-265, -30, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, -16); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                mainTextObject.text = "";
                yesButtonText.text = "A: Are you exploring new teaching practices";
                noButtonText.text = "B: Are you trying to evaluate student feedback?";
                thirdButtonText.text = "C: Are you trying to gain feedback on your existing course?";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                onBPath = false;
                numberOfDecisions++;
                twoPathImage.SetActive(false);
                threePathImage.SetActive(true);
                placeHolderBackground.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 1 && fourPathActive != true && onBPath == true)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(true);
                guyHappySprite.SetActive(false);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false); 
                textBubble.SetActive(true);
                textBubbleText.text = "You will need to contact the MSU IT Team about your concerns.";
                matthiasTextAmount = 20;
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Contact the MSU IT Team";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                numberOfDecisions++;
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                MSUITZoneImage.SetActive(true);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
            if (numberOfDecisions == 1 && fourPathActive != true && onBPath == false)
            {
                mainTextReference.SetActive(false);
                typingTextBubbleText.text = "";
                guySprite.SetActive(false);
                guyHappySprite.SetActive(true);
                guyCastingSprite.SetActive(false);
                guyHoldingStaffSprite.SetActive(false);
                textBubble.SetActive(true);
                textBubbleText.text = "Looking to gain feedback on your existing course?";
                matthiasTextAmount = 32;
                mainTextObject.rectTransform.localPosition = new Vector3(0, -85, 0);
                yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                twoPathSign.SetActive(false);
                threePathSign.SetActive(false);
                mainTextObject.text = "Contact the CTLI";
                yesButton.SetActive(false);
                noButton.SetActive(false);
                thirdButton.SetActive(false);
                fourthButton.SetActive(false);
                numberOfDecisions++;
                twoPathImage.SetActive(false);
                threePathImage.SetActive(false);
                placeHolderBackground.SetActive(false);
                CTLIZoneImage.SetActive(true);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
                StartCoroutine(TypeText());
                return;
            }
        }
    }

    public void Fourth()
    {
        if (guySprite.activeSelf == false && guyHappySprite.activeSelf == false && guyCastingSprite.activeSelf == false && guyHoldingStaffSprite.activeSelf == false)
        {
            mainTextReference.SetActive(false);
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(true);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false); textBubble.SetActive(true);
            textBubbleText.text = "Looks like you will need to contact LTD’s Accessibility and Quality Matters expert about your Inquiry!";
            matthiasTextAmount = 10;
            mainTextObject.rectTransform.localPosition = new Vector3(0, 173, 0);
            yesButton.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
            twoPathSign.SetActive(false);
            threePathSign.SetActive(false);
            mainTextObject.text = "Please contact our Accessibility and QM Expert (insert Sarah email here?)";
            yesButton.SetActive(false);
            noButton.SetActive(false);
            thirdButton.SetActive(false);
            fourthButton.SetActive(false);
            twoPathImage.SetActive(false);
            threePathImage.SetActive(false);
            placeHolderBackground.SetActive(false);
            d2LCourseBuildHouse.SetActive(false);
            accessibilityHouse.SetActive(true);
            multimediaHouse.SetActive(false);
            redevelopCourseHouse.SetActive(false);
            twoPathSignFirst.SetActive(false);
            twoPathSignSecond.SetActive(false);
            threePathSignFirst.SetActive(false);
            threePathSignSecond.SetActive(false);
            threePathSignThird.SetActive(false);
            bigTownBackground.SetActive(false);
            bigTownLeftMostSign.SetActive(false);
            bigTownLeftMiddleSign.SetActive(false);
            bigTownRightMiddleSign.SetActive(false);
            bigTownRightMostSign.SetActive(false);
            bigTownLeftMostSignHover.SetActive(false);
            bigTownLeftMiddleSignHover.SetActive(false);
            bigTownRightMiddleSignHover.SetActive(false);
            bigTownRightMostSignHover.SetActive(false);
            StartCoroutine(TypeText());
            return;
        }
    }

    public void FirstButtonHovered()
    {
        if (guySprite.activeSelf == false && guyHappySprite.activeSelf == false && guyCastingSprite.activeSelf == false && guyHoldingStaffSprite.activeSelf == false)
        {
            if (twoPathSign.activeSelf == true)
            {
                twoPathSign.SetActive(false);
                twoPathSignFirst.SetActive(true);
                twoPathSignSecond.SetActive(false);
            }
            if (threePathSign.activeSelf == true)
            {
                threePathSign.SetActive(false);
                threePathSignFirst.SetActive(true);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(false);
            }
            if (bigTownLeftMostSign.activeSelf == true)
            {
                bigTownLeftMostSign.SetActive(false);
                bigTownLeftMostSignHover.SetActive(true);
            }
        }
    }

    public void SecondButtonHovered()
    {
        if (guySprite.activeSelf == false && guyHappySprite.activeSelf == false && guyCastingSprite.activeSelf == false && guyHoldingStaffSprite.activeSelf == false)
        {
            if (twoPathSign.activeSelf == true)
            {
                twoPathSign.SetActive(false);
                twoPathSignFirst.SetActive(false);
                twoPathSignSecond.SetActive(true);
            }
            if (threePathSign.activeSelf == true)
            {
                threePathSign.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(true);
                threePathSignThird.SetActive(false);
            }
            if (bigTownLeftMiddleSign.activeSelf == true)
            {
                bigTownLeftMiddleSign.SetActive(false);
                bigTownLeftMiddleSignHover.SetActive(true);
            }
        }
    }

    public void ThirdButtonHovered()
    {
        if (guySprite.activeSelf == false && guyHappySprite.activeSelf == false && guyCastingSprite.activeSelf == false && guyHoldingStaffSprite.activeSelf == false)
        {
            if (threePathSign.activeSelf == true)
            {
                threePathSign.SetActive(false);
                threePathSignFirst.SetActive(false);
                threePathSignSecond.SetActive(false);
                threePathSignThird.SetActive(true);
            }
            if (bigTownRightMiddleSign.activeSelf == true)
            {
                bigTownRightMiddleSign.SetActive(false);
                bigTownRightMiddleSignHover.SetActive(true);
            }
        }
    }

    public void FourthButtonHovered()
    {
        if (guySprite.activeSelf == false && guyHappySprite.activeSelf == false && guyCastingSprite.activeSelf == false && guyHoldingStaffSprite.activeSelf == false)
        {
            if (bigTownRightMostSign.activeSelf == true)
            {
                bigTownRightMostSign.SetActive(false);
                bigTownRightMostSignHover.SetActive(true);
            }
        }
    }

    public void ButtonDehovered()
    {
        if (twoPathSign.activeSelf == false && (twoPathSignFirst.activeSelf == true || twoPathSignSecond.activeSelf == true))
        {
            twoPathSign.SetActive(true);
            twoPathSignFirst.SetActive(false);
            twoPathSignSecond.SetActive(false);
        }
        if (threePathSign.activeSelf == false && (threePathSignFirst.activeSelf == true || threePathSignSecond.activeSelf == true || threePathSignThird.activeSelf == true))
        {
            threePathSign.SetActive(true);
            threePathSignFirst.SetActive(false);
            threePathSignSecond.SetActive(false);
            threePathSignThird.SetActive(false);
        }
        if (bigTownLeftMiddleSignHover.activeSelf == true || bigTownLeftMostSignHover.activeSelf == true || bigTownRightMiddleSignHover.activeSelf == true || bigTownRightMostSignHover.activeSelf == true)
        {
            bigTownLeftMostSign.SetActive(true);
            bigTownLeftMostSignHover.SetActive(false);
            bigTownLeftMiddleSign.SetActive(true);
            bigTownLeftMiddleSignHover.SetActive(false);
            bigTownRightMiddleSign.SetActive(true);
            bigTownRightMiddleSignHover.SetActive(false);
            bigTownRightMostSign.SetActive(true);
            bigTownRightMostSignHover.SetActive(false);
        }
    }

    public void UpdateMatthiasText()
    {
        if (matthiasTextAmount == 1)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "My name is Matthias, and I will be your guide, an Educational Support Wizard, if you will.";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 2)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "I am here to help you find where you need to go!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 3)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(true);
            textBubbleText.text = "Think about your inquiry that you need supporting and follow the path to which your concerns best align with!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 4)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "I will get you to a team or individual that will be able to help you on your journey.";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 5)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(true);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Click which sign best aligns with your inquiry.";
            StartCoroutine(TypeText());
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 6)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false); 
            textBubble.SetActive(false);
            threePathSign.SetActive(true);
            yesButton.SetActive(true);
            noButton.SetActive(true);
            thirdButton.SetActive(true);
            textBubbleText.text = "";
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 7)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(true);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "You’ve come to the right place!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 8)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(true);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Which of the following does your question best align to?";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 9)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false); 
            textBubble.SetActive(false);
            textBubbleText.text = "";
            bigTownLeftMostSign.SetActive(true);
            bigTownLeftMiddleSign.SetActive(true);
            bigTownRightMiddleSign.SetActive(true);
            bigTownRightMostSign.SetActive(true);
            yesButton.SetActive(true);
            noButton.SetActive(true);
            thirdButton.SetActive(true);
            fourthButton.SetActive(true);
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 10)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Click on the scroll to be sent to their contact information!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 11)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            guySprite.SetActive(false);
            textBubble.SetActive(false);
            textBubbleText.text = "";
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 12)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(true);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "But we can get more specific!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 13)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false); 
            textBubble.SetActive(false);
            textBubbleText.text = "";
            threePathSign.SetActive(true);
            yesButton.SetActive(true);
            noButton.SetActive(true);
            thirdButton.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 14)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(true);
            textBubbleText.text = "Look no further than the Learning Technology and Development Team!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 15)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Click the scroll to be taken to their contacts!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 16)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false); 
            textBubble.SetActive(false);
            textBubbleText.text = "";
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 17)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(true);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Look no further than MSU EdTech!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 18)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Click the scroll to be taken to their contacts!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 19)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubble.SetActive(false);
            textBubbleText.text = "";
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 20)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "I can get you to their website!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 21)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Click the scroll to be sent to their contacts!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 22)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubble.SetActive(false);
            textBubbleText.text = "";
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 23)
        {
            typingTextBubbleText.text = "";
            textBubbleText.text = "Look no further than the Center for Teaching and Learning Innovation!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 24)
        {
            typingTextBubbleText.text = "";
            textBubbleText.text = "Click the scroll to be sent to their contacts!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 25)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubble.SetActive(false);
            textBubbleText.text = "";
            matthiasTextAmount++;
            mainTextReference.SetActive(true);
            return;
        }
        if (matthiasTextAmount == 26)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(true);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Look no further than the Learning Technology and Development Team!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 27)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Click the scroll to be taken to their contacts!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 28)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubble.SetActive(false);
            textBubbleText.text = "";
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 29)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(true);
            textBubbleText.text = "Look no further than the Center for Teaching and Learning Innovation!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 30)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Click the scroll to be taken to their contacts!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 31)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubble.SetActive(false);
            textBubbleText.text = "";
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 32)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(true);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Look no further than the Center for Teaching and Learning Innovation!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 33)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(true);
            guyHoldingStaffSprite.SetActive(false);
            textBubbleText.text = "Click the scroll to be taken to their contacts!";
            StartCoroutine(TypeText());
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 34)
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubble.SetActive(false);
            textBubbleText.text = "";
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
        if (matthiasTextAmount == 35) // Where all one-liners go
        {
            typingTextBubbleText.text = "";
            guySprite.SetActive(false);
            guyHappySprite.SetActive(false);
            guyCastingSprite.SetActive(false);
            guyHoldingStaffSprite.SetActive(false);
            textBubble.SetActive(false);
            textBubbleText.text = "";
            twoPathSign.SetActive(true);
            yesButton.SetActive(true);
            noButton.SetActive(true);
            mainTextReference.SetActive(true);
            matthiasTextAmount++;
            return;
        }
    }

    public IEnumerator TypeText()
    {
        isTyping = true;
        voiceClip.Play();
        for (int i = 0; i < textBubbleText.text.Length; i++)
        {
            typingTextBubbleText.text = textBubbleText.text.Substring(0, i + 1);
            yield return new WaitForSeconds(typingSpeed);
        }
        voiceClip.Stop();
        isTyping = false;
    }

    public void SkipTyping()
    {
        StopAllCoroutines();     // Yeah, yeah.  This is bad.  I'll stop specific coroutines if I end up using more than one.
                                 // If some other developer is seeing this and needs to add more coroutines, then just do this:
                                 // typingCoroutine = StartCoroutine(TypeText());  The variable is already set above for use.
                                 // Then, to stop it, do StopCoroutine(typingCoroutine);
        typingTextBubbleText.text = textBubbleText.text;
        voiceClip.Stop();
        isTyping = false;
    }
}
