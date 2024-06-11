import {
  FlatList,
  Image,
  ScrollView,
  Text,
  TouchableOpacity,
} from "react-native";
import { Container } from "../../components/container/style";
import { LogoViagens } from "../Viagens/style";
import {
  ButtonViagem,
  Check,
  Checklist,
  ContainerRota,
  ContentCheck,
  ContentRota,
  IconCheck,
  Lugar,
  Rota,
  TextButtonViagem,
} from "./style";
import { Shadow } from "react-native-shadow-2";
import { TitleViagens } from "../../components/ViewViagens/style";
import { IconBack } from "../ViewPost/style";

import { MaterialCommunityIcons } from "@expo/vector-icons";
import { Back } from "../../components/Button";
import { MinhasViagens } from "../../components/Logo/Logo";
import { ContainerShadowViagens, ShadowDefault } from "../../components/Shadow";

import api from "../../service/Service";
import { useCallback, useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/MyContext";
import { useFocusEffect } from "@react-navigation/native";

let checklist = [
  {
    description: "Visitar o coliseu",
    status: 1,
  },
  {
    description: "Andar de bicicleta",
    status: 1,
  },
  {
    description: "Visitar o coliseu",
    status: 0,
  },
  {
    description: "Andar de bicicleta",
    status: 0,
  },
  {
    description: "Visitar o coliseu",
    status: 0,
  },
  {
    description: "Andar de bicicleta",
    status: 0,
  },
  {
    description: "Visitar o coliseu",
    status: 1,
  },
  {
    description: "Andar de bicicleta",
    status: 1,
  },
  {
    description: "Visitar o coliseu",
    status: 0,
  },
  {
    description: "Andar de bicicleta",
    status: 0,
  },
  {
    description: "Visitar o coliseu",
    status: 0,
  },
  {
    description: "Andar de bicicleta",
    status: 0,
  },
];

export const ViagemAtual = ({ navigation, route }) => {
  const [dadosViagem, setDadosViagem] = useState(null)

  const BuscarDadosViagem = () => {
    api.get(`/Viagens/${route.params.idViagem}`)
    .then(response => {
      setDadosViagem(response.data)
      console.log(response);
    })
    .catch(erro => {
      alert(erro)
      console.log(erro);
    })
  }

  useEffect(() => {
    BuscarDadosViagem()
  }, [route.params])

  return dadosViagem != null ? (
    <Container>
      <Back navigation={navigation}/>

      <MinhasViagens />

      <ContainerShadowViagens
        render={
          <ContainerRota>
            <ContentRota>
              <Rota>Origem</Rota>
              <Lugar>{dadosViagem.endereco.cidadeOrigem}</Lugar>
            </ContentRota>

            <MaterialCommunityIcons name="airplane" size={40} color="black" />

            <ContentRota>
              <Rota>Destino</Rota>
              <Lugar>{dadosViagem.endereco.cidadeDestino}</Lugar>
            </ContentRota>
          </ContainerRota>
        }
      />

      <ContainerShadowViagens
        render={
          <Checklist>
            <TitleViagens>Rotina da viagem</TitleViagens>

            <FlatList
              data={checklist}
              renderItem={({ item }) => (
                <ContentCheck>
                  <Check>
                    {item.status === 0 ? null : (
                      <MaterialCommunityIcons
                        name="check-bold"
                        size={20}
                        color="yellowgreen"
                      />
                    )}
                  </Check>
                  <TitleViagens>Visitar o coliseu</TitleViagens>
                </ContentCheck>
              )}
            />
          </Checklist>
        }
      />

      {route.params !== undefined ? (
        route.params.type === "acompanhar" ? (
          <ShadowDefault
            render={
              <ButtonViagem bgColor={"#8531C6"}>
                <TextButtonViagem style={{ color: "#fff" }}>
                  finalizar viagem
                </TextButtonViagem>
              </ButtonViagem>
            }
          />
        ) : route.params.type === "historico" ? (
          <ShadowDefault
            render={
              <ButtonViagem
                onPress={() => navigation.navigate(`CriarPost`)}
                bgColor={"#8531C6"}
              >
                <TextButtonViagem style={{ color: "#fff" }}>
                  Adicionar post
                </TextButtonViagem>
              </ButtonViagem>
            }
          />
        ) : (
          <ShadowDefaut
            render={
              <ButtonViagem bgColor={"#8531C6"}>
                <TextButtonViagem style={{ color: "#fff" }}>
                  Iniciar viagem
                </TextButtonViagem>
              </ButtonViagem>
            }
          />
        )
      ) : null}
    </Container>
  ) : <></>;
};
