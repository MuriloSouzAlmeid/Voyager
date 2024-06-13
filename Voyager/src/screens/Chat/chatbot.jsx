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
} from "./style";
import { ShadowDefault } from "../../components/Shadow";
import { useEffect, useState } from "react";
import { Shadow } from "react-native-shadow-2";
import { KeyboardAwareScrollView } from "react-native-keyboard-aware-scroll-view";

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

export const ChatBot = ({ navigation }) => {
  const [prompt, setPrompt] = useState("");
  const [historicoChat, setHistoricoChat] = useState([]);

  const PromptSubmit = (prompt) => {
    historicoChat.push({ id: Date.now(), texto: prompt });
    setTimeout(() => {
      setHistoricoChat([
        ...historicoChat,
        { id: Date.now(), texto: "Resposta" },
      ]);
    }, 1000);

    setPrompt("");
  };

  return (
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

        <BotaoVoltar onPress={() => alert("Voltando")} />

        <ContainerChat>
          <HeaderChat>
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

          <ChatSectionBox>
            {historicoChat.map((mensagem, index) => {
              return (
                <Text key={mensagem.id}>
                  {mensagem.texto} - {index % 2 == 0 ? "usuário" : "gemini"}
                </Text>
              );
            })}
          </ChatSectionBox>

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
