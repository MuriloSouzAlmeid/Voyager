import {
  FlatList,
  Image,
  SafeAreaView,
  StatusBar,
  Text,
  View,
} from "react-native";
import { Container } from "../../components/container/style";
import {
  BotaoVoltarStyle,
  ChatSectionBox,
  ContainerChat,
  HeaderChat,
  InputPromptStyle,
  LogoGemini,
  LogoVoyager,
  PontoHeader,
  PromptChatStyle,
  PromptChatStyleShadow,
  PromptChatText,
} from "./style";
import { ShadowDefault } from "../../components/Shadow";
import { useEffect, useState } from "react";
import { Shadow } from "react-native-shadow-2";
import { KeyboardAwareScrollView } from "react-native-keyboard-aware-scroll-view";
import { GoogleGenerativeAI } from "@google/generative-ai";
import DropShadow from "react-native-drop-shadow";

//Configurando o modelo do Gemini ------------------------------------------------------------------------------

//defeinindo a minha chave API do Google AI Studio
const apiKey = "AIzaSyCAMtSLTyOYk4DaIv--qxX8eZ7dZ2XpGzk";

//instancia o objeto ganAi que vai configurar o modelo pela apiKey e pelas configurações de parâmetros
const genAi = new GoogleGenerativeAI(apiKey);

//define configurações das respostas do modelo
const generationConfig = { temperature: 0.5, candidateCount: 1 };
const systemInstruction = "Seja formal em suas respostas. Não inclua emojis em suas respostas";
const safetySettings = [
  {
    category: "HARM_CATEGORY_HATE_SPEECH",
    threshold: "BLOCK_NONE",
  },
  {
    category: "HARM_CATEGORY_SEXUALLY_EXPLICIT",
    threshold: "BLOCK_NONE",
  },
  {
    category: "HARM_CATEGORY_HARASSMENT",
    threshold: "BLOCK_NONE",
  },
  {
    category: "HARM_CATEGORY_DANGEROUS_CONTENT",
    threshold: "BLOCK_NONE",
  },
];

//instanciando o modelo
const modelo = genAi.getGenerativeModel({
  model: "gemini-1.5-flash",
  generationConfig,
  safetySettings,
  systemInstruction,
});

//instancia um chat a partir do modelo
const chat = modelo.startChat({ history: [] });

//---------------------------------------------------------------------------------------------------------------

//Componente de volvar para a tela anterior
const BotaoVoltar = ({ onPress }) => {
  return (
    <BotaoVoltarStyle onPress={onPress}>
      <Image
        style={{ height: "100%", width: "100%" }}
        source={{
          uri: "https://voyagerblobstorage.blob.core.windows.net/voyagercontainerblob/Reply-Arrow.png",
        }}
      />
    </BotaoVoltarStyle>
  );
};

//Componente de input do prompt do usuário
const InputPrompt = ({ value, setValue, onSubmit }) => {
  return (
    <Shadow
      startColor="#000"
      endColor="#000"
      distance={0}
      offset={[5, 5]}
      containerStyle={{ marginBottom: 10, position: "absolute", bottom: 10 }}
    >
      <InputPromptStyle
        placeholder={"Digite Aqui."}
        placeholderTextColor={`#BA31C6`}
        value={value}
        onChangeText={(text) => setValue(text)}
        onEndEditing={() => onSubmit(value)}
      />
    </Shadow>
  );
};

const PromptChat = ({ type, mensagem }) => {
  return (
    <>
    <PromptChatStyleShadow type={type}>
      <PromptChatStyle type={type}>
        <PromptChatText type={type}>{mensagem}</PromptChatText>
      </PromptChatStyle>
    </PromptChatStyleShadow>
    <View style={{marginBottom: 25}}></View>
    </>
  );
};

//Elemento que de fato será a tela do ChatBot
export const ChatBot = ({ navigation }) => {
  //States
  const [prompt, setPrompt] = useState("");
  const [historicoChat, setHistoricoChat] = useState([]);

  //Função que irá enviar o prompt ao gemini e obter a resposta
  const PromptSubmit = (prompt) => {
    historicoChat.push({ id: Date.now(), texto: prompt });

    setTimeout(async () => {
      await chat
        .sendMessage(prompt)
        .then((response) => {
          setHistoricoChat([
            ...historicoChat,
            { id: Date.now(), texto: response.response.text() },
          ]);
        })
        .catch((erro) => {
          setHistoricoChat([
            ...historicoChat,
            { id: Date.now(), texto: erro.response.data },
          ]);
        });
    }, 1000);

    setPrompt("");
  };

  useEffect(() => {
    console.log(historicoChat);
  }, [historicoChat]);

  return (
    //Componente para adaptar a tela à altura do teclado
    <KeyboardAwareScrollView
      contentContainerStyle={{ flexGrow: 1 }} // Ajuste para o conteúdo preencher a tela
      extraScrollHeight={100} // Adiciona um espaço extra para evitar que o teclado corte o conteúdo
    >
      <Container>
        <StatusBar
          barStyle={"dark-content"}
          translucent={true}
          backgroundColor={"#8531C6"}
        />

        <ContainerChat>
          {/* Header com as logos */}
          <HeaderChat>
            {/* Botão voltar */}
            <BotaoVoltar onPress={() => alert("Voltando")} />
            <LogoVoyager
              source={{
                uri: "https://voyagerblobstorage.blob.core.windows.net/voyagercontainerblob/logoVoyager.png",
              }}
            />
            <PontoHeader>.</PontoHeader>
            <LogoGemini
              source={{
                uri: "https://voyagerblobstorage.blob.core.windows.net/voyagercontainerblob/logoGemini.png",
              }}
            />
          </HeaderChat>

          {/* Seção de envio e resposta do chat */}
          <ChatSectionBox>
            {historicoChat.map((mensagem, index) => {
              return(
                <PromptChat key={mensagem.id} mensagem={mensagem.texto} type={index % 2 == 0 ? "usuario" : "gemini"} />
              )
            })}

          </ChatSectionBox>

          {/* Input de prompt do usuário */}
          <InputPrompt
            value={prompt}
            setValue={setPrompt}
            onSubmit={PromptSubmit}
          />
        </ContainerChat>
      </Container>
    </KeyboardAwareScrollView>
  );
};
