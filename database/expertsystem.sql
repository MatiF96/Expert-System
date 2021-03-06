PGDMP     +    ,            
    x            expertsystem    12.0    12.0                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    40961    expertsystem    DATABASE        CREATE DATABASE expertsystem WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Polish_Poland.1250' LC_CTYPE = 'Polish_Poland.1250';
    DROP DATABASE expertsystem;
                postgres    false            Λ            1259    40964    accounts    TABLE     ή   CREATE TABLE public.accounts (
    account_id integer NOT NULL,
    account_type text NOT NULL,
    account_login text NOT NULL,
    account_password text NOT NULL,
    account_fullname text,
    account_birthdate date
);
    DROP TABLE public.accounts;
       public         heap    postgres    false            Κ            1259    40962    accounts_account_id_seq    SEQUENCE        CREATE SEQUENCE public.accounts_account_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.accounts_account_id_seq;
       public          postgres    false    203                        0    0    accounts_account_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.accounts_account_id_seq OWNED BY public.accounts.account_id;
          public          postgres    false    202            Ο            1259    40979    appointments    TABLE     Η   CREATE TABLE public.appointments (
    appointment_id integer NOT NULL,
    appointment_doctor_id integer NOT NULL,
    appointment_patient_id integer NOT NULL,
    appointment_date date NOT NULL
);
     DROP TABLE public.appointments;
       public         heap    postgres    false            Ν            1259    40975 &   appointments_appointment_doctor_id_seq    SEQUENCE        CREATE SEQUENCE public.appointments_appointment_doctor_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 =   DROP SEQUENCE public.appointments_appointment_doctor_id_seq;
       public          postgres    false    207            !           0    0 &   appointments_appointment_doctor_id_seq    SEQUENCE OWNED BY     q   ALTER SEQUENCE public.appointments_appointment_doctor_id_seq OWNED BY public.appointments.appointment_doctor_id;
          public          postgres    false    205            Μ            1259    40973    appointments_appointment_id_seq    SEQUENCE        CREATE SEQUENCE public.appointments_appointment_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public.appointments_appointment_id_seq;
       public          postgres    false    207            "           0    0    appointments_appointment_id_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public.appointments_appointment_id_seq OWNED BY public.appointments.appointment_id;
          public          postgres    false    204            Ξ            1259    40977 '   appointments_appointment_patient_id_seq    SEQUENCE        CREATE SEQUENCE public.appointments_appointment_patient_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public.appointments_appointment_patient_id_seq;
       public          postgres    false    207            #           0    0 '   appointments_appointment_patient_id_seq    SEQUENCE OWNED BY     s   ALTER SEQUENCE public.appointments_appointment_patient_id_seq OWNED BY public.appointments.appointment_patient_id;
          public          postgres    false    206            
           2604    40967    accounts account_id    DEFAULT     z   ALTER TABLE ONLY public.accounts ALTER COLUMN account_id SET DEFAULT nextval('public.accounts_account_id_seq'::regclass);
 B   ALTER TABLE public.accounts ALTER COLUMN account_id DROP DEFAULT;
       public          postgres    false    202    203    203            
           2604    40982    appointments appointment_id    DEFAULT        ALTER TABLE ONLY public.appointments ALTER COLUMN appointment_id SET DEFAULT nextval('public.appointments_appointment_id_seq'::regclass);
 J   ALTER TABLE public.appointments ALTER COLUMN appointment_id DROP DEFAULT;
       public          postgres    false    207    204    207            
           2604    40983 "   appointments appointment_doctor_id    DEFAULT        ALTER TABLE ONLY public.appointments ALTER COLUMN appointment_doctor_id SET DEFAULT nextval('public.appointments_appointment_doctor_id_seq'::regclass);
 Q   ALTER TABLE public.appointments ALTER COLUMN appointment_doctor_id DROP DEFAULT;
       public          postgres    false    205    207    207            
           2604    40984 #   appointments appointment_patient_id    DEFAULT        ALTER TABLE ONLY public.appointments ALTER COLUMN appointment_patient_id SET DEFAULT nextval('public.appointments_appointment_patient_id_seq'::regclass);
 R   ALTER TABLE public.appointments ALTER COLUMN appointment_patient_id DROP DEFAULT;
       public          postgres    false    206    207    207                      0    40964    accounts 
   TABLE DATA              COPY public.accounts (account_id, account_type, account_login, account_password, account_fullname, account_birthdate) FROM stdin;
    public          postgres    false    203   $                 0    40979    appointments 
   TABLE DATA           w   COPY public.appointments (appointment_id, appointment_doctor_id, appointment_patient_id, appointment_date) FROM stdin;
    public          postgres    false    207   9$       $           0    0    accounts_account_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.accounts_account_id_seq', 1, false);
          public          postgres    false    202            %           0    0 &   appointments_appointment_doctor_id_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('public.appointments_appointment_doctor_id_seq', 1, false);
          public          postgres    false    205            &           0    0    appointments_appointment_id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public.appointments_appointment_id_seq', 1, false);
          public          postgres    false    204            '           0    0 '   appointments_appointment_patient_id_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public.appointments_appointment_patient_id_seq', 1, false);
          public          postgres    false    206            
           2606    40972    accounts accounts_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.accounts
    ADD CONSTRAINT accounts_pkey PRIMARY KEY (account_id);
 @   ALTER TABLE ONLY public.accounts DROP CONSTRAINT accounts_pkey;
       public            postgres    false    203            
           2606    40986    appointments appointments_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public.appointments
    ADD CONSTRAINT appointments_pkey PRIMARY KEY (appointment_id);
 H   ALTER TABLE ONLY public.appointments DROP CONSTRAINT appointments_pkey;
       public            postgres    false    207            
           1259    40992    fki_doctor_id    INDEX     W   CREATE INDEX fki_doctor_id ON public.appointments USING btree (appointment_doctor_id);
 !   DROP INDEX public.fki_doctor_id;
       public            postgres    false    207            
           1259    40998    fki_patient_id    INDEX     Y   CREATE INDEX fki_patient_id ON public.appointments USING btree (appointment_patient_id);
 "   DROP INDEX public.fki_patient_id;
       public            postgres    false    207            
           2606    40987    appointments doctor_id    FK CONSTRAINT        ALTER TABLE ONLY public.appointments
    ADD CONSTRAINT doctor_id FOREIGN KEY (appointment_doctor_id) REFERENCES public.accounts(account_id) NOT VALID;
 @   ALTER TABLE ONLY public.appointments DROP CONSTRAINT doctor_id;
       public          postgres    false    203    207    2703            
           2606    40993    appointments patient_id    FK CONSTRAINT        ALTER TABLE ONLY public.appointments
    ADD CONSTRAINT patient_id FOREIGN KEY (appointment_patient_id) REFERENCES public.accounts(account_id) NOT VALID;
 A   ALTER TABLE ONLY public.appointments DROP CONSTRAINT patient_id;
       public          postgres    false    203    207    2703                  xΡγββ Ε ©            xΡγββ Ε ©     