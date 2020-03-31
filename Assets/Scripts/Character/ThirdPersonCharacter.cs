using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class ThirdPersonCharacter : MonoBehaviour
{
    [SerializeField] float m_MovingTurnSpeed = 360; //�ƶ���ת����ٶ�
    [SerializeField] float m_StationaryTurnSpeed = 180; //վ��ʱת����ٶ�
    [SerializeField] float m_JumpPower = 12f; //��Ծ����������
    [Range(1f, 4f)] [SerializeField] float m_GravityMultiplier = 2f; //��������
    [SerializeField] float m_RunCycleLegOffset = 0.2f; //��ƫ��ֵ
    [SerializeField] float m_MoveSpeedMultiplier = 1f; //�ƶ��ٶ�
    [SerializeField] float m_AnimSpeedMultiplier = 1f; //���������ٶ�
    [SerializeField] float m_GroundCheckDistance = 0.1f; //���������
    [SerializeField] float m_AnimationForwardSpeed = 0.7f; //ǰ���ٶ�

    Rigidbody m_Rigidbody;
    Animator m_Animator;
    bool m_IsGrounded;
    float m_OrigGroundCheckDistance;
    const float k_Half = 0.5f;
    float m_TurnAmount;
    float m_ForwardAmount;
    Vector3 m_GroundNormal;
    float m_CapsuleHeight;
    Vector3 m_CapsuleCenter;
    CapsuleCollider m_Capsule;
    bool m_Crouching;
    float scale;
    float capsuleRadius;



    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
        m_CapsuleHeight = m_Capsule.height;
        m_CapsuleCenter = m_Capsule.center;
        scale = transform.localScale.x;
        m_GroundCheckDistance = m_Capsule.radius * scale;


        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        m_OrigGroundCheckDistance = m_GroundCheckDistance;
    }


    public void Move(Vector3 move, bool crouch, bool jump, float speed)
    {

        // ��һ���������������ת��Ϊ������ص�ת���ǰ���ٶȣ���Ҫ���ǵ���ɫͷ���ķ���
        if (move.magnitude > 1f) move.Normalize();
        move = move * speed;
        Vector3 moveWorld = move;
        moveWorld.y = 0;
        move = transform.InverseTransformDirection(move);
        CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move, m_GroundNormal); //���ݵ���ķ�����������һ����Ӧƽ����ٶȷ���.
        m_TurnAmount = Mathf.Atan2(move.x, move.z); //��z��нǣ���ʾת��Ƕ�
        m_ForwardAmount = move.z * m_AnimationForwardSpeed;

        ApplyExtraTurnRotation();

        // �ֵ���Ϳ��������������
        if (m_IsGrounded)
        {
            HandleGroundedMovement(crouch, jump); //�����Ƿ�׷�ȷ���Ƿ���Ծ�������������������ϵ��ٶ�
        }
        else
        {
            HandleAirborneMovement(moveWorld); //�����½��ٶȣ����Ҹ����������½����ò�ͬ�ĵ�������룻������Ծ���¶ײ�������
        }

        ScaleCapsuleForCrouching(crouch); //���ݶ׷����ٽ�����߶ȣ����ж��ܷ�վ��
        PreventStandingInLowHeadroom(); //�ڲ��������ĵط������¶�

        // �����в�����������ʵ��
        UpdateAnimator(move);
    }


    void ScaleCapsuleForCrouching(bool crouch)
    {
        //���µ�һ˲��ѽ��Ҹ߶Ⱥ����ĸ߶ȼ���
        if (m_IsGrounded && crouch)
        {
            if (m_Crouching) return; //ֻ���ڶ��µ�˲�䴦��һ��
            m_Capsule.height = m_Capsule.height / 2f;
            m_Capsule.center = m_Capsule.center / 2f;
            m_Crouching = true;
        }
        else
        {
            Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
            float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
            if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                //�ӽ�ɫ�ײ����϶�һ����k_Half��Ϊ�˷�ֹ�ڶ���ʱ��������˵��棬����������ƫ��  
                m_Crouching = true; //�����˾�˵���޷��ص�վ��״̬
                return;
            }
            m_Capsule.height = m_CapsuleHeight; //����ɿ���c�����������������ָ̻���ԭʼ�߶�
            m_Capsule.center = m_CapsuleCenter;
            m_Crouching = false;
        }
    }

    void PreventStandingInLowHeadroom()
    {
        // ����¶׽���һ����ɽ�����Ͳ�������
        if (!m_Crouching)
        {
            Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
            float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
            if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
            {
                m_Crouching = true;
            }
        }
    }


    void UpdateAnimator(Vector3 move)
    {
        //���¶�������
        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
        m_Animator.SetBool("Crouch", m_Crouching);
        m_Animator.SetBool("OnGround", m_IsGrounded);
        if (!m_IsGrounded)
        {
            m_Animator.SetFloat("Jump", m_Rigidbody.velocity.y);
        }

        // ������ֻ�����ں���ģ����Կ����ж���Ծ��������ֻ�����뿪����  
        // ����Ĵ��������ڶ�����������ܲ�ѭ��������ĳֻ�Ż���δ����0��0.5���ڳ�Խ��һֻ��  
        float runCycle =
            Mathf.Repeat(//��ȡ��ǰ�����ĸ��ţ�Repeat�൱��ȡģ
                m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
        float jumpLeg = (runCycle < k_Half ? 1 : -1) * m_ForwardAmount;
        if (m_IsGrounded)
        {
            m_Animator.SetFloat("JumpLeg", jumpLeg);
        }

        // ��ߵķ�������������inspector��ͼ�е���������walking/running���ʣ�������Ϊ���˶�Ӱ���ƶ����ٶ�  
        if (m_IsGrounded && move.magnitude > 0)
        {
            m_Animator.speed = m_AnimSpeedMultiplier;
        }
        else
        {
            // �ڿ���ʱ����
            m_Animator.speed = 1;
        }
    }


    void HandleAirborneMovement(Vector3 moveAir)
    {
        // ����ʱ��Ӷ��������
        Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
        m_Rigidbody.AddForce(extraGravityForce);
        moveAir.Normalize();
        //Debug.Log(moveAir);
        if (Mathf.Sqrt(m_Rigidbody.velocity.x * m_Rigidbody.velocity.x + m_Rigidbody.velocity.z * m_Rigidbody.velocity.z) < 2.0f)
            m_Rigidbody.AddForce(moveAir * 7.5f);

        m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f; //������ʱ���ж��Ƿ��ڵ�����
    }


    void HandleGroundedMovement(bool crouch, bool jump)
    {
        // ֻ���ڵ�����վ������²�������
        if (jump && !crouch && m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
        {
            // ������Ծ�������������ϵ��ٶȣ�x��z���ٶ������ﵱǰ�ٶȾ���
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
            m_IsGrounded = false;
            m_Animator.applyRootMotion = false;
            m_GroundCheckDistance = 0.1f;
            //Debug.Log(m_Rigidbody.velocity.x+" "+m_Rigidbody.velocity.z+" "+Mathf.Sqrt(m_Rigidbody.velocity.x*m_Rigidbody.velocity.x+m_Rigidbody.velocity.z*m_Rigidbody.velocity.z)+" "+m_Rigidbody.velocity.magnitude);
        }
    }

    void ApplyExtraTurnRotation()
    {
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);//�����ƶ����ٶȼ����ת����ٶ�;ת��Խ��,ת���ٶ����ӵ�Խ��
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);//����ת��
    }


    public void OnAnimatorMove()
    {
        // ʹ���������������������ƶ�������������������Ƴ�λ�õ��ٶ�
        if (m_IsGrounded && Time.deltaTime > 0)
        {
            Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

            // ����y����ƶ��ٶ� 
            v.y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity = v;
        }
    }


    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
        float actualRadius = m_Capsule.radius * scale;
        float offset = actualRadius * 1.8f;
        bool forward, back, right, left;
        bool leftForward, rightForward, leftBack, rightBack;
        Vector3 forwardVec, backVec, rightVec, leftVec;
        Vector3 leftForwardVec, rightForwardVec, leftBackVec, rightBackVec;
        forwardVec = transform.position + (Vector3.up * actualRadius) + (transform.forward * offset);
        backVec = transform.position + (Vector3.up * actualRadius) - (transform.forward * offset);
        rightVec = transform.position + (Vector3.up * actualRadius) + (transform.right * offset);
        leftVec = transform.position + (Vector3.up * actualRadius) - (transform.right * offset);
        leftForwardVec = transform.position + (Vector3.up * actualRadius) + (transform.forward * offset * 0.72f) - (transform.right * offset * 0.72f);
        rightForwardVec = transform.position + (Vector3.up * actualRadius) + (transform.forward * offset * 0.72f) + (transform.right * offset * 0.72f);
        leftBackVec = transform.position + (Vector3.up * actualRadius) - (transform.forward * offset * 0.72f) - (transform.right * offset * 0.72f);
        rightBackVec = transform.position + (Vector3.up * actualRadius) - (transform.forward * offset * 0.72f) + (transform.right * offset * 0.72f);

        forward = Physics.Raycast(forwardVec, Vector3.down, out hitInfo, m_GroundCheckDistance + actualRadius);
        back = Physics.Raycast(backVec, Vector3.down, out hitInfo, m_GroundCheckDistance + actualRadius);
        right = Physics.Raycast(rightVec, Vector3.down, out hitInfo, m_GroundCheckDistance + actualRadius);
        left = Physics.Raycast(leftVec, Vector3.down, out hitInfo, m_GroundCheckDistance + actualRadius);
        leftForward = Physics.Raycast(leftForwardVec, Vector3.down, out hitInfo, m_GroundCheckDistance + actualRadius);
        rightForward = Physics.Raycast(rightForwardVec, Vector3.down, out hitInfo, m_GroundCheckDistance + actualRadius);
        leftBack = Physics.Raycast(leftBackVec, Vector3.down, out hitInfo, m_GroundCheckDistance + actualRadius);
        rightBack = Physics.Raycast(rightBackVec, Vector3.down, out hitInfo, m_GroundCheckDistance + actualRadius);

        //bool sphereCast;
        //Ray groundRay = new Ray(transform.position + (Vector3.up * actualRadius), Vector3.down);
        //float rayLength = actualRadius*1.5f;
        //sphereCast = Physics.SphereCast(groundRay, actualRadius, rayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore);
#if UNITY_EDITOR
        Debug.DrawLine(forwardVec, forwardVec + (Vector3.down * (m_GroundCheckDistance + actualRadius)));
        Debug.DrawLine(backVec, backVec + (Vector3.down * (m_GroundCheckDistance + actualRadius)));
        Debug.DrawLine(rightVec, rightVec + (Vector3.down * (m_GroundCheckDistance + actualRadius)));
        Debug.DrawLine(leftVec, leftVec + (Vector3.down * (m_GroundCheckDistance + actualRadius)));
        Debug.DrawLine(leftForwardVec, leftForwardVec + (Vector3.down * (m_GroundCheckDistance + actualRadius)));
        Debug.DrawLine(rightForwardVec, rightForwardVec + (Vector3.down * (m_GroundCheckDistance + actualRadius)));
        Debug.DrawLine(leftBackVec, leftBackVec + (Vector3.down * (m_GroundCheckDistance + actualRadius)));
        Debug.DrawLine(rightBackVec, rightBackVec + (Vector3.down * (m_GroundCheckDistance + actualRadius)));
#endif
        //�˸�����������ж�Ϊ׹��
        //if (sphereCast)
        if (forward || back || right || left || leftForward || rightForward || leftBack || rightBack)
        {
            m_GroundNormal = hitInfo.normal;
            m_IsGrounded = true;
            m_Animator.applyRootMotion = true;

        }
        else
        {
            m_IsGrounded = false;
            m_GroundNormal = Vector3.up;
            m_Animator.applyRootMotion = false;
        }
    }
}

